using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(A) Bool", menuName = "ScriptableObjects/Actions/Bool (A)")]
public class BoolAction : Action
{
    public bool Bool;
    public override void StartAction()
    {
        base.StartAction();
    }

    public override bool Check(GameObject owner)
    {
        return Bool;
    }
}
