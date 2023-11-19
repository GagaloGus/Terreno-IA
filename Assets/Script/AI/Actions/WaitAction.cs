using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "(A) Wait", menuName = "ScriptableObjects/Actions/Wait (A)")]
public class WaitAction : Action
{
    public float minWaitTime, maxWaitTime;
    [SerializeField]
    float currentTime = 0;
    float waitTime;
    public override void StartAction()
    {
        base.StartAction();
        currentTime = 0;
        //si el tiempo minimo es menor que el mayor, los iguala
        if(maxWaitTime < minWaitTime) maxWaitTime = minWaitTime;
        //randomiza el tiempo de espera
        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    public override bool Check(GameObject owner)
    {
        //si ya ha llegado a su destino empieza la cuenta atras
        if(owner.GetComponent<NavMeshAgent>().remainingDistance <= 1)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitTime)
            {
                currentTime = 0;
                return true;
            }
        }
        return false;
    }

}
