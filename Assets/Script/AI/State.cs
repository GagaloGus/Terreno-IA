using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;

[System.Serializable]
public struct ActionParameter
{
    public Action action;
    public bool actionValue;
}

[System.Serializable]
public struct StateParameters
{
    public ActionParameter[] actionParameters;
    public State nextState;
    [Tooltip("True = Or (si se cumple una solo cambia a la siguiente, False = And")]
    public bool or;
}

public abstract class State : ScriptableObject
{
    public StateParameters[] parameters;
    protected NavMeshAgent navMeshAgent;
    public virtual State Run(GameObject owner)
    {
        foreach (StateParameters par in parameters)
        {
            bool and = true;
            for(int i = 0; i < par.actionParameters.Length; i++)
            {
                bool currentAction = par.actionParameters[i].action.Check(owner) == par.actionParameters[i].actionValue;

                and &= currentAction;
                if(par.or && currentAction) { return par.nextState; }
            }

            return and ? par.nextState : null;
            
        }

        return null;
    }

    public virtual void StartState(GameObject owner)
    {
        navMeshAgent = owner.GetComponent<NavMeshAgent>(); 
    }

    public virtual void DrawStateGizmo(GameObject owner)
    {

    }

    public void DrawActionsGizmo(GameObject owner)
    {
        foreach (StateParameters par in parameters)
        {
            for (int i = 0; i < par.actionParameters.Length; i++)
            {
                par.actionParameters[i].action.DrawGizmo(owner);
            }
        }
    }
}
