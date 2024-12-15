using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour, ILocalPositionAdapter
{
   
    [SerializeField] private Vector3 _initialDirection; // Initial Velocidty
    [SerializeField] private float _initialSpeed = 5;
    private BallSimulation _ballSimulation; // Responsável pela física da bola (movimentação e colisão)
    private BallLogic _ballLogic; // Responsável pela lógica da bola
    
    public Vector3 LocalPosition
    {
        get { return transform.localPosition;  }
        set { transform.localPosition = value; }
    }
    
    void Awake()
    {
        Vector3 velocity =  (_initialDirection == Vector3.zero) ?  
                            new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * _initialSpeed : 
                            (_initialSpeed * _initialDirection);

        _ballSimulation = new BallSimulation(velocity);
        _ballLogic = new BallLogic(this, _ballSimulation);
        _ballLogic.OnDestroyed += () => Destroy(gameObject);
        
        Score.OnScored += IncreaseSpeed;
    }
    
    void FixedUpdate()
    {
        if (GameStateManager.Instance.CurrentState == GameStateManager.GameState.Playing)
        {
            _ballLogic.FixedUpdate(Time.fixedDeltaTime);
        }
    }

    void IncreaseSpeed()
    {
        _ballSimulation.UpdateSpeed(_ballSimulation.GetSpeed() + 0.1f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _ballLogic.Hit(other.gameObject.tag);
    }
    
    public void ChangeSpeed(float speed)
    {
        _ballSimulation.UpdateSpeed(_initialSpeed);
    }
}
