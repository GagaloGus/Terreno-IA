using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "(S) Patrol", menuName = "ScriptableObjects/States/Patrol (S)")]

public class PatrolState : State
{
    [Tooltip("Los puntos por los que va a ir la IA en orden")]
    public Vector3[] patrolPoints;
    [Range(0f, 60f)]
    public float minSwapTime, maxSwapTime;

    public Texture2D nothingTexture2D;
        
    float count = 0, maxTime;
    int pointInt = 0;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, nothingTexture2D);
        //randomiza el tiempo para cambiar de punto 
        maxTime = Random.Range(minSwapTime, maxSwapTime);
    }

    public override State Run(GameObject owner)
    {

        //espera hasta que llegue a su destino para iniciar el contador
        if(navMeshAgent.remainingDistance <= 1)
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
            }
        }


        if(pointInt >= patrolPoints.Length) { pointInt = 0; }

        navMeshAgent.SetDestination(patrolPoints[pointInt]);

        return base.Run(owner);

    }

    public override void DrawStateGizmo(GameObject owner)
    {
        for(int i = 0; i < patrolPoints.Length; i++)
        {
            if (i == patrolPoints.Length - 1)
            {
                Gizmos.DrawRay(patrolPoints[i], patrolPoints[0] - patrolPoints[i]);
            }
            else
            {
                Gizmos.DrawRay(patrolPoints[i], patrolPoints[i + 1] - patrolPoints[i]);
            }
        }
    }
}
