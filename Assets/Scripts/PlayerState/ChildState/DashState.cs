using HNS.Data.PlayerData;
using HNS.FSM;
using HNS.ParentState.GroundState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : ParentGroundedState
{
    protected DashData dashData;
    public DashState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName, DashData dashData) : base(playerController, stateMachine, playerData, animBoolName)
    {
        this.dashData = dashData;
    }

    public override void CheckerState()
    {
        base.CheckerState();
    }

    public override void EnterState()
    {
        base.EnterState();
        AddForceMovement(dashData.GetMovementSpeed());
        AddForceOnDash();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicStateUpdate()
    {
        base.LogicStateUpdate();
        if(Input == Vector2.zero)
        {
            _stateMachine.ChangeState(_playerController.IdleStates);
        }
    }

    public override void PhysicsStateUpdate()
    {
        base.PhysicsStateUpdate();
    }
    public void AddForceOnDash()
    {
        Vector3 characterRotationDirection = _playerController.transform.forward;
        characterRotationDirection.y = 0f;
        _playerController.RB.velocity = characterRotationDirection * dashData.GetMovementSpeed(); 
    }
}
