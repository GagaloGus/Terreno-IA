using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int health;
    public int maxHealth;
    public bool isPaused, isInMenu;
    void Awake()
    {
        if (!instance) //comprueba que instance no tenga informacion
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //si tiene info, ya existe un GM
        {
            Destroy(gameObject);
        }

        isInMenu = true;
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            LoadScene("Menu");
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)) { health++; print("sube"); }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) { health--; print("baja"); }

        if (isPaused || isInMenu)        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void LoadScene(string sceneName)
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        if(sceneName == "Menu") { isInMenu = true; } 
        else { isInMenu = false; }

        SceneManager.LoadScene(sceneName);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ChangeHealth(int value)
    {
        health += value;
    }

    public int gm_health
    {
        get { return health; }
        set { health = value; }
    }

    public bool _isPaused
    {
        get { return isPaused; }
    }
}
