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
        public ParentGroundedState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
        {

        }
    }
}

