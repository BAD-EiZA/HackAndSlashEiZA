using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.SubState.IdleState;
using HNS.SubState.WalkState;
using HNS.Data.PlayerData;
using HNS.Input.System;

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
    public PlayerInputHandler PlayerInputs
    {
        get; private set;
    }
    public Rigidbody RB
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
        RB = GetComponent<Rigidbody>();
        PlayerInputs = GetComponent<PlayerInputHandler>();
        StateMachines.Initialize(IdleStates);
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        StateMachines.CurrentState.LogicStateUpdate();
        //StateMachines.CurrentState.PhysicsStateUpdate();
    }
}
