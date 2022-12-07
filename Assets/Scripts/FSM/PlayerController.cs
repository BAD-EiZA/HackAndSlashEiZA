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
    public AttackState AttackStates
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
    public SpecialAttackState SpecialAttackStates
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
    [SerializeField] private AttackData attackData;
    [SerializeField] public Transform GroundCheck;

    [SerializeField] public float currentSkillGauge;
    [SerializeField] float startSkillGauge;
    public bool isAnimFinish = false;
    private void Awake()
    {
        MainCameraTransform = Camera.main.transform;
        StateMachines = new StateMachine();
        IdleStates = new IdleState(this, StateMachines, playerData, "Idle");
        SpecialAttackStates = new SpecialAttackState(this, StateMachines, playerData, "SpecialAttack");
        WalkStates = new WalkState(this, StateMachines, playerData, "Walk");
        DashStates = new DashState(this, StateMachines, playerData, "Dash", dashData);
        AttackStates = new AttackState(this, StateMachines, playerData, "Attack", attackData);
    }
    private void Start()
    {
        
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        PlayerInputs = GetComponent<PlayerInputHandler>();
        StateMachines.Initialize(IdleStates);
        currentSkillGauge = startSkillGauge;
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
    public void AnimationFinish()
    {
        isAnimFinish = true;
    }
    public void SpecialAttackGaugeReduces(float gauge)
    {
        currentSkillGauge -= gauge;
        UIManager.Instance.GaugeSlider.value -= currentSkillGauge;

    }
    public IEnumerator DelayDash()
    {
        yield return new WaitForSeconds(dashData.DashLimitCooldown);
    }
    public void StartDelayDash()
    {
        StartCoroutine(DelayDash());
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
    public void StartsDealDamage()
    {
        DamageDealer.instance.StartDealDamage();
    }
    public void EndsDealDamage()
    {
        DamageDealer.instance.EndDealDamage();
    }
    public void MovementForce(float Speed)
    {
        RB.AddForce(MoveDirection() * Speed - GetCurrentHorizontalVelocity(), ForceMode.Impulse);
    }
    public void AddsForceOnDash()
    {
        Vector3 characterRotationDirection = transform.forward;
        characterRotationDirection.y = 0f;
        RB.velocity = characterRotationDirection * dashData.GetMovementSpeed();
    }

}
