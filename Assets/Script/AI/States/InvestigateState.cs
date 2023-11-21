using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Investigate", menuName = "ScriptableObjects/States/Investigate (S)")]
public class InvestigateState : State
{
    [Range(0f, 100f)]
    [Tooltip("Porcentaje de velocidad reducida, 0% (nada) hasta 100% (entero)")]
    public int speedDecrease = 50;
    public Texture2D questionIcon;

    Vector3 lastPlayerPos;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, questionIcon);

        lastPlayerPos = target.transform.position;

        //reproduce el sonido de huh
        audioPlayer.PlaySFX("huh", 0.4f);

        animator.SetBool("isInvestigating", true);
        animator.SetBool("isWalking", true);
    }

    public override State Run(GameObject owner)
    {
        navMeshAgent.speed = navOgSpeed - navOgSpeed * ((float)speedDecrease / 100); 
        navMeshAgent.SetDestination(lastPlayerPos);

        return base.Run(owner);

    }
}
