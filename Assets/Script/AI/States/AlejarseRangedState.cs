using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Alejarse Ranged", menuName = "ScriptableObjects/States/Alejarse RangedAtk (S)")]
public class AlejarseRangedState : State
{
    public float distance = 0.1f;
    [Range(0f, 30)]
    public float angle, maxSpeedIncrease;
    Vector3 direction;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);

        animator.SetBool("isWalking", true);
        animator.SetBool("goingBackwards", true);
    }

    public override State Run(GameObject owner)
    {
        //mire al player
        owner.transform.LookAt(target.transform.position);

        navMeshAgent.speed = navOgSpeed * maxSpeedIncrease;
        //randomiza la nueva posicion
        if (navMeshAgent.remainingDistance < distance/5)
        {
            float randomAngle = Random.Range(-angle, angle);

            //angulo random + direccion hacia atras del player + distancia;
            direction = Quaternion.Euler(0, randomAngle, 0) * -(target.transform.position - owner.transform.position).normalized * distance;
            navMeshAgent.SetDestination(direction + owner.transform.position);
        }

        return base.Run(owner);
    }
}
