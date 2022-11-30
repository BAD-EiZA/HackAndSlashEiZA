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
    }
}

