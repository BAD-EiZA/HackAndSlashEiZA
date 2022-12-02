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

        public void MoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            Debug.Log(MovementInput);
        }
        public void JumpInput(InputAction.CallbackContext context)
        {

        }
    }
}

