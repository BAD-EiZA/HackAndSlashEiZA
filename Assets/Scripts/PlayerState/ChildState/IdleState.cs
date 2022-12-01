using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.ParentState.GroundState;
using HNS.Data.PlayerData;

namespace HNS.SubState.IdleState
{
    public class IdleState : ParentGroundedState
    {
        public IdleState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
        {
        }

        public override void CheckerState()
        {
            base.CheckerState();
        }

        public override void EnterState()
        {
            base.EnterState();
            //_playerData.ResetSpeedModifier();
            _playerController.ResetVelocity();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void LogicStateUpdate()
        {
            base.LogicStateUpdate();
            if(Input.x != 0 || Input.y != 0)
            {
                _stateMachine.ChangeState(_playerController.WalkStates);
                Debug.Log("Walk State");
            }
        }

        public override void PhysicsStateUpdate()
        {
            base.PhysicsStateUpdate();
        }
    }
}

