using HNS.Data.PlayerData;
using HNS.FSM;
using HNS.ParentState.GroundState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackState : ParentGroundedState
{
    protected AttackData attackData;
    public AttackState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName, AttackData attackData) : base(playerController, stateMachine, playerData, animBoolName)
    {
        this.attackData = attackData;
    }

    public override void CheckerState()
    {
        base.CheckerState();
    }

    public override void EnterState()
    {
        base.EnterState();
        
        _playerController.Anim.applyRootMotion = true;
        Attacktimepassed = 0f;
        _playerController.Anim.SetTrigger("Attacking");
        
        
    }

    public override void ExitState()
    {
        base.ExitState();
        _playerController.Anim.applyRootMotion = false;
    }

    public override void LogicStateUpdate()
    {
        base.LogicStateUpdate();
        Attacktimepassed += Time.time;
        clipLength = _playerController.Anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = _playerController.Anim.GetCurrentAnimatorStateInfo(0).speed;
        //AddForceDash(attackData.GetMovementSpeed());
        //AddForceOnDash(_playerData.GetMovementSpeed());
        if (!IsInState)
        {
            if (Attacktimepassed >= clipLength / clipSpeed)
            {
                if(Input == Vector2.zero)
                {
                    _stateMachine.ChangeState(_playerController.IdleStates);
                }
                
            }
            if (Attacktimepassed >= clipLength / clipSpeed && Input != Vector2.zero)
            {
                _stateMachine.ChangeState(_playerController.WalkStates);
            }
            //else if (Attacktimepassed >= clipLength / clipSpeed && DashInput && _playerController.DashStates.CheckerCanDash())
            //{
            //    _stateMachine.ChangeState(_playerController.DashStates);
            //}
        }
        
    }

    public override void PhysicsStateUpdate()
    {
        base.PhysicsStateUpdate();
    }
}
