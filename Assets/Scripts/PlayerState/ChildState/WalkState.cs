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
    }
}

