using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public PlayerScript player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.GetComponent<PlayerScript>() != null)
            {
                player.GetComponent<PlayerScript>().isGameOver = true;
                player.GetComponent<PlayerScript>().playerWon = true;
            }
        }    
    }
}
