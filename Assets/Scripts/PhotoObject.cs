using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoObject : MonoBehaviour
{
    public int photoNum;

    public GameObject galleryStorage;

    public Collider2D Activator;

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            galleryStorage.GetComponent<GalleryStorage>().UnlockPhoto(photoNum);

            Activator.enabled = false;
        }
    }
}
