using System.Collections.Generic;
using UnityEngine;

public static class ConeCastExtension
{
    public static RaycastHit[] ConeCastAll(Vector3 origin, float maxRadius, Vector3 direction, float coneAngle)
    {
        RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin - new Vector3(0, 0, maxRadius), maxRadius, direction);
        List<RaycastHit> coneCastHitList = new List<RaycastHit>();

        if (sphereCastHits.Length > 0)
        {
            for (int i = 0; i < sphereCastHits.Length; i++)
            {

                Vector3 hitPoint = sphereCastHits[i].point;
                Vector3 directionToHit = hitPoint - origin;
                float angleToHit = Vector3.Angle(direction, directionToHit);

                if (angleToHit < coneAngle)
                {
                    coneCastHitList.Add(sphereCastHits[i]);
                }
            }
        }

        RaycastHit[] coneCastHits = new RaycastHit[coneCastHitList.Count];
        coneCastHits = coneCastHitList.ToArray();

        return coneCastHits;

        /*
         * float angle = 45f; // Ángulo deseado en grados
float distance = 100f; // Distancia máxima del rayo
Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)); // Convierte el ángulo a un vector
RaycastHit hit; // Información sobre el objeto que se encuentra en la trayectoria del rayo

// Lanza los dos rayos desde el forward del objeto
if (Physics.Raycast(transform.position, transform.forward + direction, out hit, distance)) {
    Debug.Log("Rayo 1 golpeó " + hit.collider.gameObject.name);
}
if (Physics.Raycast(transform.position, transform.forward - direction, out hit, distance)) {
    Debug.Log("Rayo 2 golpeó " + hit.collider.gameObject.name);
}
En este ejemplo, se lanza un par de rayos desde el forward del objeto actual. El ángulo deseado se especifica en grados y se convierte a un vector usando las funciones Mathf.Sin y Mathf.Cos. Los dos rayos se lanzan en direcciones opuestas usando los vectores transform.forward + direction y transform.forward - direction. La información sobre los objetos que se encuentran en la trayectoria de los rayos se almacena en la variable hit.
        */
    }
}