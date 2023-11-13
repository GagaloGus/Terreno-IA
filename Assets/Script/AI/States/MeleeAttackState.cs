using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Melee Atk", menuName = "ScriptableObjects/States/Melee Atk (S)")]
public class MeleeAttackState : State
{
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
    }
    public override State Run(GameObject owner)
    {
        return base.Run(owner);
    }
}

