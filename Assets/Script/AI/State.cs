using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : ScriptableObject
{
    public Action action;
    public bool actionValue;
    public State nextState;

    protected NavMeshAgent navMeshAgent;
    public virtual State Run(GameObject owner)
    {
        if (action.Check(owner) == actionValue)
        {
            return nextState;
        }
        return null;
    }

    public virtual void StartState(GameObject owner)
    {
        navMeshAgent = owner.GetComponent<NavMeshAgent>(); 
    }
}
