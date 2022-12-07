using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM.StateReferences;
using HNS.FSM;
using HNS.Data.PlayerData;

public class ParentAbilityState : State
{
    protected bool _specialAttackInput;
    protected bool _specialAttackStop;
    public ParentAbilityState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
    }

    public override void CheckerState()
    {
        base.CheckerState();
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Ability State");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicStateUpdate()
    {
        base.LogicStateUpdate();
        _specialAttackInput = _playerController.PlayerInputs.SpecialAttackInput;
        _specialAttackStop = _playerController.PlayerInputs.SpecialAttackInputStop;
        if(Input != Vector2.zero)
        {
            _stateMachine.ChangeState(_playerController.SpecialAttackStates);
        }
    }

    public override void PhysicsStateUpdate()
    {
        base.PhysicsStateUpdate();
    }
    
}
