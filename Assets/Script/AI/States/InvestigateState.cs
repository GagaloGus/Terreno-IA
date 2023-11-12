using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Investigate", menuName = "ScriptableObjects/States/Investigate (S)")]
public class InvestigateState : State
{
    [Range(0f, 100f)]
    [Tooltip("Porcentaje de velocidad reducida, 0% (nada) hasta 100% (entera)")]
    public int speedDecrease = 50;
    public Sprite questionIcon;

    float originalSpeed;
    GameObject target;
    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        owner.transform.Find("questionIcon").gameObject.GetComponent<SpriteRenderer>().sprite = questionIcon;

        originalSpeed = navMeshAgent.speed;
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public override State Run(GameObject owner)
    {
        navMeshAgent.speed = originalSpeed * (speedDecrease / 100); 
        navMeshAgent.SetDestination(target.transform.position);

        return base.Run(owner);
    }
}
