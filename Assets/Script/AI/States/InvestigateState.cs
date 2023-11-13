using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Investigate", menuName = "ScriptableObjects/States/Investigate (S)")]
public class InvestigateState : State
{
    [Range(0f, 100f)]
    [Tooltip("Porcentaje de velocidad reducida, 0% (nada) hasta 100% (entera)")]
    public int speedDecrease = 50;
    public Texture2D questionIcon;

    float originalSpeed;
    Vector3 targetPos;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, questionIcon);

        originalSpeed = navMeshAgent.speed;
        targetPos = FindObjectOfType<PlayerMovement>().gameObject.transform.position;
    }

    public override State Run(GameObject owner)
    {
        navMeshAgent.speed = originalSpeed * (speedDecrease / 100); 
        navMeshAgent.SetDestination(targetPos);

        return base.Run(owner);
    }
}
