using UnityEngine;

public class BallSimulation
{
    private Vector3 _initialVelocity;
    private Vector3 _currentVelocity;
    
    // Construtor
    public BallSimulation (Vector3 initialVelocity)
    {
        _currentVelocity = initialVelocity;
    }
    
    public Vector3 UpdatePosition(Vector3 position, float deltaTime)
    {
        return position + _currentVelocity * deltaTime;
    }

    public void UpdateSpeed(float speed)
    {
        _currentVelocity = _currentVelocity.normalized * speed;
    }
    
    public void HandleCollision(string tag)
    {
        if (tag == "HorizontalWall")
        {
            _currentVelocity = new Vector3(_currentVelocity.x, -_currentVelocity.y);
        }
        else if (tag == "Paddle")
        {
            _currentVelocity = new Vector3(-_currentVelocity.x, _currentVelocity.y);
            Score.OnScored?.Invoke();
        }
    }
}
