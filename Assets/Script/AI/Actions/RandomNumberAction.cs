using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(A) RNG", menuName = "ScriptableObjects/Actions/RNGAction")]
public class RandomNumberAction : Action
{
    [Tooltip("Esto es un random entre 0 y la variable, la variable indica como de improbable sera que salga True (0 siendo siempre true)")]
    [Range(0, 100000)]
    public int maxNumber;
    public override bool Check(GameObject owner)
    {
        return Random.Range(0, (float)maxNumber) == 0;
    }
}
