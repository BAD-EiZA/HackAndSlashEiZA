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

        public float GetMovementSpeed()
        {
            return BaseSpeed * SpeedModifier;
        }
        public float ResetSpeedModifier()
        {
            return SpeedModifier = 0;
        }
    }
}

