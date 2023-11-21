using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool playerDied;

    int health;
    public int maxHealth;
    public bool isPaused;
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
        playerDied = false;
        health = maxHealth;
    }

    private void Update()
    {
        //si tu vida es 0 o menos vuevle al Menu
        if (health <= 0)
        {
            Death();
        }

        //si el juego esta pausado o la escena es el menu puedes usar el raton
        if (isPaused || SceneManager.GetActiveScene().name == "Menu")        
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) { health++; }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) { health--; }
    }

    void Death()
    {
        playerDied = true;
    }

    public void LoadScene(string sceneName)
    {
        isPaused = false;
        health = maxHealth; //pone la vida al maximo
        Time.timeScale = 1.0f;
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

    public bool _playerDied
    {
        get { return playerDied; }
    }
}
