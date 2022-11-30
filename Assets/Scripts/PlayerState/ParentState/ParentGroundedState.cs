using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.Data.PlayerData;

namespace HNS.ParentState.GroundState
{
    public class ParentGroundedState : State
    {
        protected Vector2 Input;
        public ParentGroundedState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
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
            Input = _playerController.PlayerInputs.MovementInput;
        }

        public override void PhysicsStateUpdate()
        {
            base.PhysicsStateUpdate();
        }
    }
}

