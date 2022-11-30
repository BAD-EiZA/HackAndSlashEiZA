using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM.StateReferences;

namespace HNS.FSM
{
    public class StateMachine
    {
        public State CurrentState
        {
            get; private set;
        }
        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.EnterState();
        }
        public void ChangeState(State upcomingState)
        {
            CurrentState.ExitState();
            CurrentState = upcomingState;
            CurrentState.EnterState();
        }
    }
}

