using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;

    IEnumerator Respawn(Collider2D col)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;

        col.transform.position = respawnPoint.position;
    }
    private void OnTriggerEnter2D(Collider2D col)       //Set the player's position back to the respawn position
    {
        if (col.transform.CompareTag("Player"))
        {
            StartCoroutine(Respawn(col));

        }
    }

}
