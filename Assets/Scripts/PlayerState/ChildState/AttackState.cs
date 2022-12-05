using HNS.Data.PlayerData;
using HNS.FSM;
using HNS.ParentState.GroundState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : ParentGroundedState
{

    public AttackState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
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
        if (Attacktimepassed >= clipLength / clipSpeed && AttackInput)
        {
            
            //_stateMachine.ChangeState(_playerController.AttackStates);
            
        }
        if(Attacktimepassed >= clipLength / clipSpeed && Input == Vector2.zero)
        {
            _stateMachine.ChangeState(_playerController.IdleStates);
        }
        //if (Attacktimepassed >= clipLength / clipSpeed && Input == Vector2.zero)
        //{
        //    _stateMachine.ChangeState(_playerController.IdleStates);
        //}
        //if(Attacktimepassed >= clipLength / clipSpeed && Input != Vector2.zero)
        //{
        //    _stateMachine.ChangeState(_playerController.WalkStates);
        //}
    }

    public override void PhysicsStateUpdate()
    {
        base.PhysicsStateUpdate();
    }
}
