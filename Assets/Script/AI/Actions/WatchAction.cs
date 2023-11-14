using System.Collections;
using System.Collections.Generic;
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

        RaycastHit[] colliders = Physics.SphereCastAll(eyePoint, distance, Vector3.forward);

        foreach (RaycastHit ray in colliders)
        {
            if (ray.collider.GetComponent<PlayerMovement>())
            {
                Vector3 directionToCollider = (ray.collider.transform.position - eyePoint).normalized;
                float angleToCollider = Vector3.Angle(eyePoint, directionToCollider);

                if(angleToCollider < angle/2) 
                {
                    return true;
                }
            }
        }

        return false;  
        
    }
    public override void DrawGizmo(GameObject owner)
    {
        Vector3 eyePoint = owner.transform.position + Vector3.up * height;

        Vector3 bottomLeft = Quaternion.Euler(-angle, -angle, 0) * owner.transform.forward * distance + eyePoint;
        Vector3 bottomRight = Quaternion.Euler(-angle, angle, 0) * owner.transform.forward * distance + eyePoint;
        Vector3 topRight = Quaternion.Euler(angle, angle, 0) * owner.transform.forward * distance + eyePoint;
        Vector3 topLeft = Quaternion.Euler(angle, -angle, 0) * owner.transform.forward * distance + eyePoint;
        
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
