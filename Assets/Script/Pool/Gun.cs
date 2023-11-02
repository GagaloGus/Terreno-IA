using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject gunPoint;
    public GameObjPool pool;
    public float recoilForce, gunSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            //acceder a un obj de la pull
            GameObject bullet = pool.GetFirstInactiveGameObject();
            if (bullet != null)
            {
                //activar el objeto
                bullet.SetActive(true);
                //cambiar posicion de bala a la punta pistola
                bullet.transform.position = gunPoint.transform.position;
                bullet.GetComponent<Bullet>()._speed = gunSpeed;
                bullet.GetComponent<Bullet>()._direction = gunPoint.transform.up;

                GetComponent<Rigidbody>().AddForce(-transform.forward * recoilForce * 100);
            }
        }
    }
}
