using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoObject : MonoBehaviour
{
    public int photoNum;

    public GameObject galleryStorage;

    public Collider2D ActivatorCol;

    public SpriteRenderer ActivatorSprite;


    float x = 0;
    float pos;

    private void Start()
    {
        pos = transform.position.x;
    }
    private void Update()       //Little float animation
    {
        x += 0.02f;
        pos = pos + Mathf.Sin(x);

        transform.Translate(Vector3.up * Mathf.Sin(x) * 0.002f );
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            galleryStorage.GetComponent<GalleryStorage>().UnlockPhoto(photoNum);

            ActivatorCol.enabled = false;
            ActivatorSprite.enabled = false;
        }
    }
}
