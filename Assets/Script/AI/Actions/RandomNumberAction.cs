using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(A) RNG", menuName = "ScriptableObjects/Actions/RNG (A)")]
public class RandomNumberAction : Action
{
    [Tooltip("Random entre 0 y maxNumber, indica como de improbable sera que se cumpla (0 siendo siempre true)")]
    [Range(0, 1000)]
    public int maxNumber;

    public override void StartAction()
    {
        base.StartAction();
    }

    public override bool Check(GameObject owner)
    {
        return Random.Range(0, (float)maxNumber) == 0;
    }
}
