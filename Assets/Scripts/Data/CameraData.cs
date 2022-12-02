using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HNS.Data.CameraData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/BaseData")]
    public class CameraData : ScriptableObject
    {
        [SerializeField] private float directionAngle;

    }
}

