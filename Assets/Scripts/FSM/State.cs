using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.Data.PlayerData;

namespace HNS.FSM.StateReferences
{
    public class State
    {
        [Header("Reference")]
        protected PlayerController _playerController;
        protected StateMachine _stateMachine;
        protected PlayerData _playerData;
        protected Vector2 Input;

        protected float _startTime;
        protected string _animBoolName;
        protected bool IsInState;

        public State(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this._playerController = playerController;
            this._stateMachine = stateMachine;
            this._playerData = playerData;
            this._animBoolName = animBoolName;
        }

        public virtual void EnterState()
        {
            CheckerState();
            _playerController.Anim.SetBool(_animBoolName, true);
            _startTime = Time.time;
            IsInState = false;
        }
        public virtual void ExitState()
        {
            _playerController.Anim.SetBool(_animBoolName, false);
            IsInState = true;
        }
        public virtual void LogicStateUpdate()
        {
            Input = _playerController.PlayerInputs.MovementInput;
        }
        public virtual void PhysicsStateUpdate()
        {
            CheckerState();
        }
        public virtual void CheckerState()
        {

        }
    }
}

