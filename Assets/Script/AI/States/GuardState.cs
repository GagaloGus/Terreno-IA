using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "(S) Guard", menuName = "ScriptableObjects/States/Guard (S)")]
public class GuardState : State
{
    public Vector3 guardPoint;

    public override State Run(GameObject owner)
    {
        navMeshAgent.SetDestination(guardPoint);

        return base.Run(owner);

    }
}
