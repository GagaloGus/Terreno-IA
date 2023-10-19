using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public Action action;
    public bool actionValue;
    public State nextState;
    public abstract State Run(GameObject owner);
}
