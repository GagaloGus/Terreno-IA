using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    protected GameObject target;
    public virtual void StartAction()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public abstract bool Check(GameObject owner);

    public virtual void DrawGizmo(GameObject owner) 
    {
        
    }
}
