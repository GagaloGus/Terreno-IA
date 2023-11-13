using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Attack", menuName = "ScriptableObjects/States/Attack (S)")]
public class AttackState : State
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
