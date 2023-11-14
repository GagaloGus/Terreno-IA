using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "(S) Chase", menuName = "ScriptableObjects/States/Chase (S)")]
public class ChaseState : State
{
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
    }

    public override State Run(GameObject owner)
    {
        navMeshAgent.SetDestination(target.transform.position);

        return base.Run(owner);
    }
}
