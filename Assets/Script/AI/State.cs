using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;

[System.Serializable]
public struct StateParameters
{
    public Action action;
    public bool actionValue;
    public State nextState;
}

public abstract class State : ScriptableObject
{
    public StateParameters[] parameters;
    protected NavMeshAgent navMeshAgent;
    public virtual State Run(GameObject owner)
    {
        foreach (StateParameters par in parameters)
        {
            if (par.action.Check(owner) == par.actionValue)
            {
                return par.nextState;
            }
        }

        return null;
    }

    public virtual void StartState(GameObject owner)
    {
        navMeshAgent = owner.GetComponent<NavMeshAgent>(); 
    }

    public void DrawAllGizmos(GameObject owner)
    {
        foreach (StateParameters par in parameters)
        {
            par.action.DrawGizmo(owner);
        }
    }
}
