using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Confused", menuName = "ScriptableObjects/States/Confused (S)")]
public class ConfusedState : State
{
    public bool savePositionToPatrol;
    public PatrolState patrolState;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);

        if (savePositionToPatrol) { patrolState.newPosition = owner.transform.position; }
    }

    public override State Run(GameObject owner)
    {

        return base.Run(owner);
    }
}
