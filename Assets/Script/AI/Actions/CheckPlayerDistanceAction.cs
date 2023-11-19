using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(A) Check Player Distance", menuName = "ScriptableObjects/Actions/Check Player Distance (A)")]
public class CheckPlayerDistanceAction : Action
{
    public int playerMinDistance = 4;

    public override void StartAction()
    {
        base.StartAction();
    }

    public override bool Check(GameObject owner)
    {
        //si la distancia entre el player y el enemigo es menor o igual al radio devuelve true
        if (Vector3.Distance(owner.transform.position, target.transform.position) < playerMinDistance)
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
