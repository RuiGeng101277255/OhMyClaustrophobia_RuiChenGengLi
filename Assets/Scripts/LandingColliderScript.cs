using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingColliderScript : MonoBehaviour
{
    public PlayerScript player;

    private void OnTriggerEnter(Collider other)
    {
        player.SetLanded();
    }
}
