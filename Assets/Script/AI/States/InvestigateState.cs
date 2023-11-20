using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Investigate", menuName = "ScriptableObjects/States/Investigate (S)")]
public class InvestigateState : State
{
    [Range(0f, 100f)]
    [Tooltip("Porcentaje de velocidad reducida, 0% (entero) hasta 100% (nada)")]
    public int speedDecrease = 50;
    public Texture2D questionIcon;

    float originalSpeed;
    Vector3 targetPos;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, questionIcon);

        //reproduce el sonido de huh
        audioPlayer.PlaySFX("huh", 0.4f);

        originalSpeed = navMeshAgent.speed;
        targetPos = target.transform.position;

        animator.SetBool("isInvestigating", true);
        animator.SetBool("isWalking", true);
    }

    public override State Run(GameObject owner)
    {
        navMeshAgent.speed = originalSpeed * ((float)speedDecrease / 100); 
        navMeshAgent.SetDestination(targetPos);

        return base.Run(owner);

    }
}
