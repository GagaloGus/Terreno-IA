using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(A) Wait", menuName = "ScriptableObjects/Actions/Wait (A)")]
public class WaitAction : Action
{
    public float waitTime;
    float currentTime = 0;
    public override bool Check(GameObject owner)
    {
        currentTime += Time.deltaTime;
        if (currentTime > waitTime)
        {
            return true;
        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Vector3 coolPosition = owner.transform.position + Vector3.right * 2;
        Gizmos.DrawRay(coolPosition,
            Vector3.up * CoolFunctions.MapValues(currentTime, waitTime, 0, 0, waitTime) - coolPosition);

    }
}
