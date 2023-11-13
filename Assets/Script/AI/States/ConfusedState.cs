using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Confused", menuName = "ScriptableObjects/States/Confused (S)")]
public class ConfusedState : State
{
    [Range(1f, 5f)]
    public float boingTime;

    public float boingForce;
    float currentTime;

    public override void StartState(GameObject owner)
    {
        currentTime = 0;
        base.StartState(owner);
    }

    public override State Run(GameObject owner)
    {
        currentTime += Time.deltaTime;
        if (currentTime > boingTime)
        {
            owner.GetComponent<Rigidbody>().velocity = Vector3.up * boingForce;
            currentTime = 0;
        }
        return base.Run(owner);
    }
}
