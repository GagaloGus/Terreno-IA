using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "(S) Guard", menuName = "ScriptableObjects/State/GuardState")]
public class GuardState : State
{
    public Vector3 guardPoint;

    public override State Run(GameObject owner)
    {
        owner.GetComponent<NavMeshAgent>().SetDestination(guardPoint);

        if(action.Check(owner) == actionValue)
        {
            return nextState;
        }
        return this;

    }
}
