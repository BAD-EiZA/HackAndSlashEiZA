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
        private float dashInputStartTime;
        public bool IsJumping = false;
        private float holdTime = 0.2f;
        private void Update()
        {
            CheckDashTime(); 
        }
        public void MoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            Debug.Log(MovementInput);
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

