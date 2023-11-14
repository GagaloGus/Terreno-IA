using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "(S) Patrol", menuName = "ScriptableObjects/States/Patrol (S)")]

public class PatrolState : State
{
    [Tooltip("Los puntos por los que va a ir la IA en orden")]
    public List<Vector3> patrolPoints = new();
    [Range(0f, 60f)]
    public float minSwapTime, maxSwapTime;

    public Texture2D nothingTexture2D;
        
    float count = 0, maxTime;
    int pointInt = 0;

    [HideInInspector]
    public Vector3 newPosition = Vector3.zero;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, nothingTexture2D);
        //randomiza el tiempo para cambiar de punto 
        maxTime = Random.Range(minSwapTime, maxSwapTime);

        if(newPosition != Vector3.zero)
        {
            patrolPoints.Add(newPosition);
            newPosition = Vector3.zero;
        }
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


        if(pointInt >= patrolPoints.Count) { pointInt = 0; }

        navMeshAgent.SetDestination(patrolPoints[pointInt]);

        return base.Run(owner);

    }

    public override void DrawStateGizmo(GameObject owner)
    {
        for(int i = 0; i < patrolPoints.Count; i++)
        {
            if (i == patrolPoints.Count - 1)
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
