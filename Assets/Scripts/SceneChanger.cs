using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OpenSpecificScene(string SceneName)
    {
        if (SceneName != "quit")
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
        else
        {
            Application.Quit();
        }
    }

    public void OpenClosePauseScene(bool open)
    {
        if (open)
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
    }
}
