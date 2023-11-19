using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "(A) Hear", menuName = "ScriptableObjects/Actions/Hear (A)")]
public class HearAction : Action
{
    public float hearRadius;

    public override void StartAction()
    {
        base.StartAction();
    }

    public override bool Check(GameObject owner)
    {
        //si la distancia entre el player y el enemigo es menor o igual al radio devuelve true
        if (Vector3.Distance(target.transform.position, owner.transform.position) <= hearRadius)
        {
            return true;
        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.DrawWireSphere(owner.transform.position, hearRadius);
    }
}
