using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "(S) Chase", menuName = "ScriptableObjects/States/Chase (S)")]
public class ChaseState : State
{
    private GameObject target;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public override State Run(GameObject owner)
    {
        Vector3 targetPos = target.transform.position;
        navMeshAgent.SetDestination(targetPos);

        return base.Run(owner);
    }
}
