using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Confused", menuName = "ScriptableObjects/States/Confused (S)")]
public class ConfusedState : State
{
    public bool savePositionToPatrol;

    public Texture2D questionIcon;

    public override void StartState(GameObject owner)
    {
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, questionIcon);
        if (savePositionToPatrol) { owner.GetComponent<PatrolPoints>().AddPatrolPoint(owner.transform.position); }

        audioPlayer.PlaySFX("huh", 0.5f);
    }

    public override State Run(GameObject owner)
    {
        owner.transform.Rotate(0, 0.3f, 0);
        return base.Run(owner);
    }
}
