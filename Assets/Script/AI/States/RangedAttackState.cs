using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) RangedAtk", menuName = "ScriptableObjects/States/Ranged Atk (S)")]
public class RangedAttackState : State
{
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
    }
    public override State Run(GameObject owner)
    {
        owner.transform.LookAt(target.transform.position);
        return base.Run(owner);
    }
}
