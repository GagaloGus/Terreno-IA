using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Roll Away", menuName = "ScriptableObjects/States/RollAway (S)")]
public class RollAwayState : State
{
    public float rollDistance;
    Vector3 newPos;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);

        newPos = owner.transform.right * rollDistance + owner.transform.position;
        navMeshAgent.SetDestination(newPos);

        animator.SetTrigger("roll");
    }

    public override State Run(GameObject owner)
    {
        return base.Run(owner);
    }

    public override void DrawStateGizmo(GameObject owner)
    {
        Gizmos.DrawWireSphere(newPos, 4);
    }
}
