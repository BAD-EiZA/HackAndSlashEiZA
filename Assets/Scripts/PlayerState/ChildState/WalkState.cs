using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.ParentState.GroundState;
using HNS.Data.PlayerData;

namespace HNS.SubState.WalkState
{
    public class WalkState : ParentGroundedState
    {
        public WalkState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
        {
        }

        public override void CheckerState()
        {
            base.CheckerState();
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void LogicStateUpdate()
        {
            base.LogicStateUpdate();
            if(Input.x == 0)
            {
                _stateMachine.ChangeState(_playerController.IdleStates);
                Debug.Log("Idle State");
            }
            _playerController.RB.AddForce(_playerData.GetMovementSpeed() * _playerController.MoveDirection() - GetCurrentHorizontalVelocity(), ForceMode.VelocityChange);
        }

        public override void PhysicsStateUpdate()
        {
            base.PhysicsStateUpdate();
        }
        public Vector3 MoveDirection()
        {
            return new Vector3(Input.x, 0f, Input.y);
        }
        private Vector3 GetCurrentHorizontalVelocity()
        {
            Vector3 currentVelocity;
            currentVelocity = _playerController.RB.velocity;
            currentVelocity.y = 0f;
            return currentVelocity;
        }
    }
}

