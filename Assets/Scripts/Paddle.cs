using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] string inputAxis;
    [SerializeField] private float movimentSpeedScale = 5f;
    [SerializeField] private float positionScale = 3f;
    private float _yLimit = 3.7f;
    void FixedUpdate()
    {
       if(Input.GetAxis(inputAxis) != 0){
           float move = Input.GetAxisRaw(inputAxis) * movimentSpeedScale * Time.deltaTime;
           Vector3 newPosition = transform.position + new Vector3(0, move, 0);
           newPosition.y = Mathf.Clamp(newPosition.y, -_yLimit, _yLimit);
           transform.position = newPosition;
       }
    }
}
