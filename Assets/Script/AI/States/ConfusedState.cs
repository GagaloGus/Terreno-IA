using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Confused", menuName = "ScriptableObjects/States/Confused (S)")]
public class ConfusedState : State
{
    public bool savePositionToPatrol;

    public override void StartState(GameObject owner)
    {
        base.StartState(owner);

        //si la variable es true, guarda la posicion en el array de puntos de patrulla 
        if (savePositionToPatrol) { owner.GetComponent<PatrolPoints>().AddPatrolPoint(owner.transform.position); }

        animator.SetBool("isWalking", false);
    }

    public override State Run(GameObject owner)
    {
        //rota
        owner.transform.Rotate(0, 0.3f, 0);
        return base.Run(owner);
    }
}
