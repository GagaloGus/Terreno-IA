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

        animator.SetBool("isWalking", true);
        animator.SetBool("goingBackwards", false);
    }

    public override State Run(GameObject owner)
    {
        //persigue al player mientras le mira
        owner.transform.LookAt(target.transform.position);
        navMeshAgent.SetDestination(target.transform.position);

        return base.Run(owner);
    }
}
