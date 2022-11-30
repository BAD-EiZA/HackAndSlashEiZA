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

        protected float _startTime;
        protected string _animBoolName;

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
        }
        public virtual void ExitState()
        {
            _playerController.Anim.SetBool(_animBoolName, false);
        }
        public virtual void LogicStateUpdate()
        {

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

