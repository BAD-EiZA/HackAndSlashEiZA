using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.ParentState.GroundState;
using HNS.Data.PlayerData;
using UniGLTF;

namespace HNS.SubState.WalkState
{
    public class WalkState : ParentGroundedState
    {
        public WalkState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
        {
            InitializeData();
        }
        public void InitializeData()
        {
            _playerData.timeTargetRotation.y = 0.14f;
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
            if (Input.x == 0f && Input.y == 0f)
            {
                _stateMachine.ChangeState(_playerController.IdleStates);
                _playerController.Anim.SetFloat("Speed", 0f);
                Debug.Log("Idle State");
            }
            //_playerData.SetSpeedModifier(1);
            AddForceMovement(_playerData.GetMovementSpeed());

        }
        public override void PhysicsStateUpdate()
        {
            base.PhysicsStateUpdate();
        }
        
    }
}

