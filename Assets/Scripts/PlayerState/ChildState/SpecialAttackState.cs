using HNS.Data.PlayerData;
using HNS.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackState : ParentAbilityState
{
    public SpecialAttackState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
    }

    public override void CheckerState()
    {
        base.CheckerState();
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Special State");
        //_playerController.SpecialAttackGaugeReduces(5);
    }

    public override void ExitState()
    {
        base.ExitState();
        //_playerController.isAnimFinish = false;
    }

    public override void LogicStateUpdate()
    {
        base.LogicStateUpdate();
        if(Input == Vector2.zero && _playerController.isAnimFinish == true)
        {
            _stateMachine.ChangeState(_playerController.IdleStates);
        }
        if (Input != Vector2.zero && _playerController.isAnimFinish == true)
        {
            _stateMachine.ChangeState(_playerController.WalkStates);
        }
    }

    public override void PhysicsStateUpdate()
    {
        base.PhysicsStateUpdate();
    }
}
