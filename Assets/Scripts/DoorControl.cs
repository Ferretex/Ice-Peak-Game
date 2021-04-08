using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public float openHeight, closeHeight;

    public void OnButtonDown()
    {
        if(transform.position.y <= openHeight)
        {
            transform.Translate(Vector2.up * Time.deltaTime);

            AudioSource audioSource = GetComponent<AudioSource>();  //door open sfx
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            
        }
    }

    public void OnButtonUp()
    {
        if (transform.position.y >= closeHeight)
        {
            transform.Translate(Vector2.down * Time.deltaTime);

            AudioSource audioSource = GetComponent<AudioSource>();   //door shut sfx
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = Random.Range(0.5f, 1f);
                audioSource.PlayOneShot(audioSource.clip);
            }

        }

    }
}
