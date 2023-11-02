using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "(A) Hear", menuName = "ScriptableObjects/Actions/HearAction")]
public class HearAction : Action
{
    public float hearRadius;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] cosos = Physics.SphereCastAll(owner.transform.position, hearRadius, Vector3.up);

        foreach (RaycastHit hit in cosos)
        {
            if (hit.collider.GetComponent<PlayerMovement>())
            {
                return true;
            }

        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.DrawWireSphere(owner.transform.position, hearRadius);
    }
}