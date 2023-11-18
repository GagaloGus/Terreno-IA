using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject gunPoint;
    public GameObjPool pool;
    public float recoilForce, gunSpeed;

    List<string> meows = new();
    public int numberOfMeowSFX;
    AudioPlayer audioPlayer;
    private void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();

        //añade los nombres de los efectos de sonido de meow
        for (int i = 1; i <= numberOfMeowSFX; i++)
        {
            meows.Add($"meow{i}");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !GameManager.instance._isPaused)
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
                bullet.GetComponent<Bullet>()._direction = gunPoint.transform.forward;

                //fuerza recoil hacia atras
                GetComponent<Rigidbody>().AddForce(-transform.forward * recoilForce * 100);

                //reproduce un meow aleatorio
                audioPlayer.PlaySFX(meows[Random.Range(0, meows.Count)], 0.4f);
            }
        }
    }
}
