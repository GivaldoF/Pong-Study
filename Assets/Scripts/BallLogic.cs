using System;
using UnityEngine;
public class BallLogic
{
    private ILocalPositionAdapter _ballPosition;
    private BallSimulation _ballSimulation;

    public event Action OnDestroyed;
    public BallLogic(ILocalPositionAdapter ballPosition, BallSimulation ballSimulation)
    {
        this._ballPosition = ballPosition;
        this._ballSimulation = ballSimulation;
    }

    public void FixedUpdate(float deltaTime)
    {
        _ballPosition.LocalPosition = _ballSimulation.UpdatePosition(_ballPosition.LocalPosition, deltaTime);
    }

    public void Hit(string tag)
    {
        if(tag == "VerticalWall")
            OnDestroyed?.Invoke();
        else
        {
            _ballSimulation.HandleCollision(tag);
        }
    }
}
