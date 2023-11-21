using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "(A) Reach Destination", menuName = "ScriptableObjects/Actions/Reach Destination (A)")]
public class ReachedDestinationAction : Action
{

    public override void StartAction()
    {
        base.StartAction();
    }

    public override bool Check(GameObject owner)
    {
        //si ha llegado a su destino con tanto margen devuelve true
        if(owner.GetComponent<NavMeshAgent>().remainingDistance <= owner.GetComponent<NavMeshAgent>().stoppingDistance)
        {
            return true;
        }
        return false;
    }
}
