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
    //public Transform MainCameraTransform
    //{
    //    get; private set;
    //}
    public StateMachine StateMachines
    {
        get; private set;
    }
    public DashState DashStates
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
    public Transform MainCameraTransform
    {
        get; private set;
    }
    #endregion
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DashData dashData;
    private void Awake()
    {
        MainCameraTransform = Camera.main.transform;
        StateMachines = new StateMachine();
        IdleStates = new IdleState(this, StateMachines, playerData, "Idle");
        WalkStates = new WalkState(this, StateMachines, playerData, "Walk");
        DashStates = new DashState(this, StateMachines, playerData, "Dash", dashData);
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
    public void ResetVelocity()
    {
        RB.velocity = Vector3.zero;
    }
    public Vector3 MoveDirection()
    {
        return new Vector3(PlayerInputs.MovementInput.x, 0f, PlayerInputs.MovementInput.y);
    }
    public Vector3 GetCurrentHorizontalVelocity()
    {
        Vector3 currentVelocity;
        currentVelocity = RB.velocity;
        currentVelocity.y = 0f;
        return currentVelocity;
    }

}
