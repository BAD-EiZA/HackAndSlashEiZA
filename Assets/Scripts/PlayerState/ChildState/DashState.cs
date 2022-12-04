using HNS.Data.PlayerData;
using HNS.FSM;
using HNS.ParentState.GroundState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : ParentGroundedState
{
    protected DashData dashData;
    private float startTime;
    private int consecutiveDashUsed;
    public bool CanDash { get; private set; }
    private float lastDashTime;
    public DashState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName, DashData dashData) : base(playerController, stateMachine, playerData, animBoolName)
    {
        this.dashData = dashData;
    }
    public bool CheckerCanDash()
    {
        return CanDash && Time.time >= lastDashTime + dashData.DashCooldown;
    }
 
    public void ResetCanDash() => CanDash = true;
    public override void CheckerState()
    {
        base.CheckerState();
    }

    public override void EnterState()
    {
        base.EnterState();
        CanDash = false;
        lastDashTime = Time.time;
        _playerController.PlayerInputs.UseDashInput();
        AddForceOnDash();
        AddForceMovement(dashData.GetMovementSpeed());
        
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
        if(Input != Vector2.zero)
        {
            _stateMachine.ChangeState(_playerController.WalkStates);
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
