using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "(S) Patrol", menuName = "ScriptableObjects/State/PatrolState")]

public class PatrolState : State
{
    [Tooltip("Los puntos por los que va a ir la IA en orden")]
    public Vector3[] patrolPoints;
    [Range(0f, 60f)]
    public float minSwapTime, maxSwapTime;
        
    float count = 0, maxTime;
    int pointInt = 0;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        //randomiza el tiempo para cambiar de punto 
        maxTime = Random.Range(minSwapTime, maxSwapTime);
    }

    public override State Run(GameObject owner)
    {

        count+= Time.deltaTime;
        if(count >= maxTime)
        {
            //le suma uno al contador del array
            pointInt++;
            //reinicia el contador
            count = 0;
            //randomiza el tiempo para cambiar de punto otra vez
            maxTime = Random.Range(minSwapTime, maxSwapTime);
            Debug.Log("Cambio");
        }

        if(pointInt >= patrolPoints.Length) { pointInt = 0; }

        navMeshAgent.SetDestination(patrolPoints[pointInt]);

        return base.Run(owner);

    }
}
