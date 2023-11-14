using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Melee Atk", menuName = "ScriptableObjects/States/Melee Atk (S)")]
public class MeleeAttackState : State
{
    [Range(0, 30)]
    public float maxTimeUntilAttack, maxTimeUntilMove;
    public float atkWaitTime, currentATime,
        moveWaitTime, currentMTime;
    public override void StartState(GameObject owner)
    {
        currentATime = 0; currentMTime = 0;

        atkWaitTime = Random.Range(0, maxTimeUntilAttack);
        moveWaitTime = Random.Range(0, maxTimeUntilMove);
        base.StartState(owner);
    }
    public override State Run(GameObject owner)
    {
        Vector3 movePosition;

        currentATime+= Time.deltaTime;
        if(currentATime > atkWaitTime)
        {
            Debug.Log("Le pega");
            currentATime = 0;
            atkWaitTime = Random.Range(0, maxTimeUntilAttack);
        }
        else if(currentMTime > moveWaitTime)
        {
            movePosition = target.transform.position + new Vector3(Random.Range(1, 4), target.transform.position.y, Random.Range(1, 4));
            navMeshAgent.SetDestination(movePosition);
        }

        

        return base.Run(owner);
    }


}

