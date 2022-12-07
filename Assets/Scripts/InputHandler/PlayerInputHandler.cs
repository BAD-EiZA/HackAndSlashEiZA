using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HNS.Input.System
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput
        {
            get; private set; 
        }
        public bool DashInput
        {
            get; private set;
        }
        public bool DashInputStop
        {
            get; private set;
        }
        public bool AttackInput
        {
            get; private set;
        }
        public bool AttackInputStop
        {
            get; private set;
        }
        public bool SpecialAttackInput
        {
            get; private set;
        }
        public bool SpecialAttackInputStop
        {
            get; private set;
        }
        private float specialAttackInputStartTime;
        private float attackInputStartTime;
        private float dashInputStartTime;
        private float holdTime = 0.1f;
        private void Update()
        {
            CheckDashTime(); 
        }
        public void MoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            Debug.Log(MovementInput);
        }
        public void OnPrimaryAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInput = true;
                AttackInputStop = false;
                attackInputStartTime = Time.time;
            }
            else if (context.canceled)
            {
                AttackInputStop = true;
            }
        }
        public void OnDashInput(InputAction.CallbackContext context)
        {

            if (context.started)
            {
                DashInput = true;
                DashInputStop = false;
                dashInputStartTime = Time.time;
            }
            else if (context.canceled)
            {
                DashInputStop = true;
            }
            
        }
        public void OnSpecialAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                SpecialAttackInput = true;
                SpecialAttackInputStop = false;
                specialAttackInputStartTime = Time.time;
            }
            else if (context.canceled)
            {
                SpecialAttackInputStop = true;
            }
        }
        public void UseSpecialAttack() => SpecialAttackInput = false;
        public void UseDashInput() => DashInput = false;
        private void CheckDashTime()
        {
            if(Time.time >= dashInputStartTime + holdTime)
            {
                DashInput = false;
            }
        }
    }
}

