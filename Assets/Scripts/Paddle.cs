using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField] string _inputAxis;
    [SerializeField] private float _moveSpeed = 5f;
    private float _yLimit = 3.7f;
    void FixedUpdate()
    {
       if(Input.GetAxis(_inputAxis) != 0){
           float move = Input.GetAxisRaw(_inputAxis) * _moveSpeed * Time.deltaTime;
           Vector3 newPosition = transform.position + new Vector3(0, move, 0);
           newPosition.y = Mathf.Clamp(newPosition.y, -_yLimit, _yLimit);
           transform.position = newPosition;
       }
    }
}
