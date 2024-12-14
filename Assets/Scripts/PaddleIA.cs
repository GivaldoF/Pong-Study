using System;
using UnityEngine;

public class PaddleIA : MonoBehaviour
{
    [SerializeField] private bool _isEnabled = false;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Ball _ball;
    [SerializeField] private float _reactionTime = 0.1f;
    [SerializeField] private float _randomFactor = 0.5f;
    [SerializeField] private float _visionRange = 5f;
    [SerializeField] private float _yLimit = 3.7f; // Vertical movement limit

    private Transform _transform;
    private Transform _ballTransform;
    private float _nextMoveTime;
    private float _targetY;

    private void Awake()
    {
        if (!_ball)
        {
            throw new NullReferenceException("Ball object not found");
        }

        // Transform components cache
        _transform = transform;
        _ballTransform = _ball.transform;
    }

    void FixedUpdate()
    {
        if (_isEnabled)
        {
            if (Time.time >= _nextMoveTime)
            {
                UpdateTargetPosition();
                _nextMoveTime = Time.time + _reactionTime;
            }
            Move();
        }
    }

    void UpdateTargetPosition()
    {
        if (Mathf.Abs(_ballTransform.localPosition.x - _transform.localPosition.x) <= _visionRange)
        {
            _targetY = _ballTransform.localPosition.y + UnityEngine.Random.Range(-_randomFactor, _randomFactor);
            _targetY = Mathf.Clamp(_targetY, -_yLimit, _yLimit); // Apply vertical limit to target position
        }
        else
        {
            Debug.Log("Bola está longe!");
        }
    }

    void Move()
    {
        float step = _moveSpeed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(_transform.localPosition.x, _targetY, _transform.localPosition.z);
        _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, targetPosition, step);
    }
}