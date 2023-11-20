using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) RangedAtk", menuName = "ScriptableObjects/States/Ranged Atk (S)")]
public class RangedAttackState : State
{
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);

        animator.SetBool("isWalking", false);
    }
    public override State Run(GameObject owner)
    {
        //se queda quieto mientras apunta al player
        owner.transform.LookAt(target.transform.position);
        return base.Run(owner);
    }
}
