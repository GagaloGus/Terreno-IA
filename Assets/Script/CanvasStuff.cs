using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasStuff : MonoBehaviour
{
    Slider healthSlider;
    public GameObject menuPausa;
    GameObject guiaArmaTexto;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = transform.Find("health").gameObject.GetComponent<Slider>();
        menuPausa.SetActive(false);
        Time.timeScale = 1.0f;

        guiaArmaTexto = transform.Find("guia arma").gameObject;
        guiaArmaTexto.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CoolFunctions.MapValues(
            GameManager.instance.gm_health, 
            0, GameManager.instance.maxHealth, 
            0, 1);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.PauseGame();
            menuPausa.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            guiaArmaTexto.SetActive(false);
        }
    }
}
