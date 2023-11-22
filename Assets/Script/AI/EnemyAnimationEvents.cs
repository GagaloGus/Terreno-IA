using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    public void ShootBullet(float gunSpeed)
    {
        //coje al player
        GameObject target = FindObjectOfType<PlayerMovement>().gameObject;
        //coje el punto del cañon de donde disparar
        GameObject gunPoint = transform.Find("cannon").Find("puntoDisparo").gameObject;
        //coje la pool del StateMachine
        GameObjPool pool = GetComponent<StateMachine>().bulletPool;

        GameObject bullet = pool.GetFirstInactiveGameObject();
        if (bullet != null)
        {
            //activar el objeto
            bullet.SetActive(true);

            //cambia la rotacion de la bala para que apunte hacia el player
            bullet.transform.forward = (target.transform.position - gunPoint.gameObject.transform.position).normalized;

            //cambiar posicion de bala a la punta pistola
            bullet.transform.position = gunPoint.transform.position;

            //cambia la velocidad y direccion
            bullet.GetComponent<Bullet>()._speed = gunSpeed;
            bullet.GetComponent<Bullet>()._direction = (target.transform.position - gunPoint.gameObject.transform.position).normalized;

            GetComponent<AudioPlayer>().PlaySFX("shoot");
        }
    }

    public void GangamStyleResetScene()
    {
        GameManager.instance.LoadScene("Menu");
    }
}
