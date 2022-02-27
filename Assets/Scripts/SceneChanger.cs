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
}
