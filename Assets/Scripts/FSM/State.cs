using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    [Header("Reference")]
    protected PlayerController _playerController;
    protected StateMachine _stateMachine;
    protected PlayerData _playerData;

    protected float _startTime;
    protected string _animBoolName;

    public State(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, float startTime, string animBoolName)
    {
        this._playerController = playerController;
        this._stateMachine = stateMachine;
        this._playerData = playerData;
        this._startTime = startTime;
        this._animBoolName = animBoolName;
    }

    public virtual void EnterState()
    {
        CheckerState();
        _startTime = Time.time;
    }
    public virtual void ExitState()
    {

    }
    public virtual void LogicStateUpdate()
    {

    }
    public virtual void PhysicsStateUpdate()
    {
        CheckerState();
    }
    public virtual void CheckerState()
    {

    }
}
