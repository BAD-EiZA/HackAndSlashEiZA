using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HNS.Data.PlayerData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/BaseData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] public float BaseSpeed = 5f;
        [SerializeField] public float SpeedModifier = 1f;
        [SerializeField] public Vector3 currentTargetRotation;
        [SerializeField] public Vector3 timeTargetRotation;
        [SerializeField] public Vector3 dampedTargetRotationCurrentVelocity;
        [SerializeField] public Vector3 dampedTargetRotationPassedTime;

        public Vector3 GetCurrentTargetRotation() => currentTargetRotation;
        public Vector3 GetTimeTargetRotation() => timeTargetRotation;
        public Vector3 GetDampTargetRotationCurrent() => dampedTargetRotationCurrentVelocity;
        public Vector3 GetDampRotatePassTime() => dampedTargetRotationPassedTime;
        public float GetMovementSpeed()
        {
            return BaseSpeed * SpeedModifier;
        }
        public float SetSpeedModifier(int value) => SpeedModifier = value;

        
        
    }
}

