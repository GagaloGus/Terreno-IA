using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Alejarse Ranged", menuName = "ScriptableObjects/States/Alejarse RangedAtk (S)")]
public class AlejarseRangedState : State
{
    public float distance = 0.1f;
    [Range(0f, 30)]
    public float angle = 2;
    Vector3 direction;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
    }

    public override State Run(GameObject owner)
    {
        if(navMeshAgent.remainingDistance < distance/4)
        {
            float randomAngle = Random.Range(-angle, angle);

            //angulo random + direccion hacia atras del player + distancia;
            direction = Quaternion.Euler(0, randomAngle, 0) * -(target.transform.position - owner.transform.position).normalized * distance;
            navMeshAgent.SetDestination(direction + owner.transform.position);
        }

        return base.Run(owner);
    }
}
