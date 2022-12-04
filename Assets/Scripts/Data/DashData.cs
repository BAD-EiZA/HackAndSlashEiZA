using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/DashData")]
public class DashData : ScriptableObject
{
    [SerializeField] public float BaseSpeed = 5f;
    [SerializeField] public float SpeedModifier = 2f;
    public float GetMovementSpeed()
    {
        return BaseSpeed * SpeedModifier;
    }
}
