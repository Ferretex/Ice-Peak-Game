using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D col)       //Set the player's position back to the respawn position
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.position = respawnPoint.position;
        }
    }

}
