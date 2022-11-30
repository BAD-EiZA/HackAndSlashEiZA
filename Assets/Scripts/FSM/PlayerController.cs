using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator Anim
    {
        get; private set; 
    }
    public StateMachine StateMachines
    {
        get; private set;
    }

    private void Awake()
    {
        StateMachines = new StateMachine();
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
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
