using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZonesScript : MonoBehaviour
{

    [SerializeField] Transform respawnPoint;
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            respawnPoint.position = col.transform.position;
        }
    }
}
