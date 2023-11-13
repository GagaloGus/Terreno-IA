using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(A) Check Player Distance", menuName = "ScriptableObjects/Actions/Check Player Distance (A)")]
public class CheckPlayerDistanceAction : Action
{
    GameObject target;
    public int playerMinDistance = 4;
    public override bool Check(GameObject owner)
    {
        target = FindObjectOfType<PlayerMovement>().gameObject;
        if(Vector3.Distance(owner.transform.position, target.transform.position) < playerMinDistance)
        {
            return true;
        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.DrawRay(owner.transform.position, (target.transform.position - owner.transform.position).normalized * playerMinDistance);
    }
}
