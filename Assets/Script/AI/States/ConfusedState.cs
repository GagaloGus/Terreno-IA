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
        //cambia la textura del icono encima del enemigo al de pregunta
        base.ChangeTextureQuestionPlane(owner, questionIcon);
        
        audioPlayer.PlaySFX("huh", 0.4f);

        //si la variable es true, guarda la posicion en el array de puntos de patrulla 
        if (savePositionToPatrol) { owner.GetComponent<PatrolPoints>().AddPatrolPoint(owner.transform.position); }

    }

    public override State Run(GameObject owner)
    {
        //rota
        owner.transform.Rotate(0, 0.3f, 0);
        return base.Run(owner);
    }
}
