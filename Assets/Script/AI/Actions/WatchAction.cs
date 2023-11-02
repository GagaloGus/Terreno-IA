using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "(A) Watch", menuName = "ScriptableObjects/Actions/WatchAction")]
public class WatchAction : Action
{
    public float visionMaxDistance;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] conehits = ConeCastExtension.ConeCastAll(owner.transform.position, visionMaxDistance , owner.transform.forward, 45);

        foreach (RaycastHit ray in conehits)
        {
            if(ray.collider.GetComponent<PlayerMovement>())
            {
                Debug.Log("te miro");
                return true;
            }
        }
        Debug.LogWarning("no te miro");
        return false;

    }


}
