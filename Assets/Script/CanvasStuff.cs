using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasStuff : MonoBehaviour
{
    Slider healthSlider;
    public GameObject menuPausa;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = transform.Find("health").gameObject.GetComponent<Slider>();
        menuPausa.SetActive(false);
        Time.timeScale = 1.0f;
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
    }
}
