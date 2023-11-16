using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
        if(maxWaitTime < minWaitTime) maxWaitTime = minWaitTime;

        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    public override bool Check(GameObject owner)
    {
        currentTime += Time.deltaTime;
        if (currentTime > waitTime)
        {
            currentTime = 0;
            return true;
        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Vector3 coolPosition = owner.transform.position + Vector3.right * 2;
        Gizmos.DrawCube(coolPosition,
            Vector3.up * CoolFunctions.MapValues(currentTime, waitTime, 0, 0, waitTime));

    }
}
