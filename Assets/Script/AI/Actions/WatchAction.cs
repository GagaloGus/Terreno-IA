using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "(A) Watch", menuName = "ScriptableObjects/Actions/Watch (A)")]
public class WatchAction : Action
{
    [Tooltip("Distancia de vision")]
    public float distance = 10;
    [Tooltip("Angulo de vision")]
    public float angle = 30;
    [Tooltip("Altura de los ojos del personaje")]
    public float height;

    public override void StartAction()
    {
        base.StartAction();
    }

    public override bool Check(GameObject owner)
    {
        Vector3 eyePoint = owner.transform.position + Vector3.up * height;

        Vector3 direction = target.transform.position - eyePoint;
        float watchAngle = Vector3.Angle(direction, owner.transform.forward);

        if(-angle/2 < watchAngle && 
            watchAngle < angle/2 && 
            Vector3.Distance(eyePoint, target.transform.position) <= distance)
        {
            return true;
        }
        return false;
        
    }
    public override void DrawGizmo(GameObject owner)
    {
        Vector3 eyePoint = owner.transform.position + Vector3.up * height;

        Vector3 bottomLeft = Quaternion.Euler(-angle /2, -angle /2, 0) * owner.transform.forward * distance + eyePoint;
        Vector3 bottomRight = Quaternion.Euler(-angle /2, angle /2, 0) * owner.transform.forward * distance + eyePoint;
        Vector3 topRight = Quaternion.Euler(angle /2, angle /2, 0) * owner.transform.forward * distance + eyePoint;
        Vector3 topLeft = Quaternion.Euler(angle /2, -angle /2, 0) * owner.transform.forward * distance + eyePoint;
        
        //aristas de la piramide
        Gizmos.DrawRay(eyePoint, bottomLeft - eyePoint);
        Gizmos.DrawRay(eyePoint, bottomRight - eyePoint);
        Gizmos.DrawRay(eyePoint, topRight - eyePoint);
        Gizmos.DrawRay(eyePoint, topLeft - eyePoint);

        //base
        Gizmos.DrawRay(topLeft, topRight - topLeft);
        Gizmos.DrawRay(topLeft, bottomLeft - topLeft);
        Gizmos.DrawRay(bottomRight, topRight - bottomRight);
        Gizmos.DrawRay(bottomRight, bottomLeft - bottomRight);
    }

}
