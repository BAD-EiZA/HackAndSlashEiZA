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
        public bool JumpInput
        {
            get; private set;
        }
        public bool JumpInputStop
        {
            get; private set;
        }
        private float jumpInputStartTime;
        public void MoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            Debug.Log(MovementInput);
        }
        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
        }
    }
}

