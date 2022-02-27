using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text GameResultTimer;
    public TMP_Text GameOverTimer;

    // Start is called before the first frame update
    void Start()
    {
        GameResultTimer.text = GameStatistics.Instance().getPlayerWon() ? "YOU WIN!" : "YOU LOSE!";
        GameOverTimer.text = "Time Left: " + (int)GameStatistics.Instance().getFinalGameTimer() + "s";
    }
}
