using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour, ILocalPositionAdapter
{
    [FormerlySerializedAs("Velocity")] 
    public Vector3 initialVelocity; // Velocidade Inicial

    private BallSimulation _ballSimulation; // Responsável pela física da bola (movimentação e colisão)
    private BallLogic _ballLogic; // Responsável pela lógica da bola

    public Vector3 LocalPosition
    {
        get { return transform.localPosition;  }
        set { transform.localPosition = value; }
    }
    
    void Awake()
    {
        _ballSimulation = new BallSimulation(initialVelocity);
        _ballLogic = new BallLogic(this, _ballSimulation);
        _ballLogic.OnDestroyed += () => Destroy(gameObject);
    }
    void FixedUpdate()
    {
        _ballLogic.FixedUpdate(Time.fixedDeltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _ballLogic.Hit(other.gameObject.tag);
    }
}
