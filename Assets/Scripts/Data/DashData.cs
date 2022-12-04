using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/DashData")]
public class DashData : ScriptableObject
{
    [SerializeField] public float BaseSpeed = 5f;
    [SerializeField] public float SpeedModifier = 2f;
    [SerializeField] public float TimeConsiderConsecutive { get; private set; } = 1f;
    [SerializeField] public int ConsecutiveDashLimit { get; private set; } = 2;
    [SerializeField] public float DashLimitCooldown { get; private set; } = 1.75f;
    [SerializeField] public float DashCooldown = 0.6f;
    public float GetMovementSpeed()
    {
        return BaseSpeed * SpeedModifier;
    }
}
