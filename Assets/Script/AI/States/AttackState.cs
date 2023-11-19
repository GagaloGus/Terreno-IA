using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(S) Attack", menuName = "ScriptableObjects/States/Attack (S)")]
public class AttackState : State
{
    public Texture2D alertIcon;
    public override void StartState(GameObject owner)
    {
        //establece todo lo necesario para entrar a la "fase ataque"
        base.StartState(owner);
        base.ChangeTextureQuestionPlane(owner, alertIcon);
        cannon.GetComponent<Animator>().SetBool("attackMode", true);

    }

    public override State Run(GameObject owner)
    {
        return base.Run(owner);
    }
}
