using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameManager.instance.LoadScene(sceneName);
    }

    public void ContinueGame()
    {
        GameManager.instance.ContinueGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
