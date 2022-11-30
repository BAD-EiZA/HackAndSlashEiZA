using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.SubState.IdleState;
using HNS.SubState.WalkState;
using HNS.Data.PlayerData;

public class PlayerController : MonoBehaviour
{
    #region Properties
    public Animator Anim
    {
        get; private set; 
    }
    public StateMachine StateMachines
    {
        get; private set;
    }
    public IdleState IdleStates
    {
        get; private set;
    }
    public WalkState WalkStates
    {
        get; private set;
    }
    #endregion

    [SerializeField] private PlayerData playerData;
    private void Awake()
    {
        StateMachines = new StateMachine();
        IdleStates = new IdleState(this, StateMachines, playerData, "Idle");
        WalkStates = new WalkState(this, StateMachines, playerData, "Walk");
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
        StateMachines.Initialize(IdleStates);
    }
    private void Update()
    {
        StateMachines.CurrentState.LogicStateUpdate();
    }
    private void FixedUpdate()
    {
        StateMachines.CurrentState.PhysicsStateUpdate();
    }
}
