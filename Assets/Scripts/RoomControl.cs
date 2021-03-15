using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    public GameObject followCam;

    private void OnTriggerEnter2D(Collider2D other)     //When entering a room, set that room's camera to active
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            followCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)      //On exit, set it to false
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            followCam.SetActive(false);
        }
    }
}
