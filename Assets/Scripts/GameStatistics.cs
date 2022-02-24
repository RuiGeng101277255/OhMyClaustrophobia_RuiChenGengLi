using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    private static GameStatistics _instance;
    public static GameStatistics Instance { get { return _instance; } }

    //Game Variables
    private static float FinalGameTimer;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(_instance);
                return;
            }
        }
    }

    public void setFinalGameTimer(float t)
    {
        FinalGameTimer = t;
    }

    public float getFinalGameTimer()
    {
        return FinalGameTimer;
    }
}
