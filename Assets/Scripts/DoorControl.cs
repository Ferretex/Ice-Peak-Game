using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public float openHeight, closeHeight;

    bool played = true;
    public void OnButtonDown()
    {
        if(transform.position.y <= openHeight)
        {
            transform.Translate(Vector2.up * Time.deltaTime);

            AudioSource audioSource = GetComponent<AudioSource>();  //door open sfx
            if (played == false)
            {
                audioSource.PlayOneShot(audioSource.clip);
                played = true;
            }

        }
        else
        {
            played = false;
        }
    }

    public void OnButtonUp()
    {
        if (transform.position.y >= closeHeight)
        {
            transform.Translate(Vector2.down * Time.deltaTime);

            AudioSource audioSource = GetComponent<AudioSource>();   //door shut sfx
            if (played == false)
            {
                audioSource.pitch = Random.Range(0.5f, 1f);
                audioSource.PlayOneShot(audioSource.clip);
                played = true;
            }

        }
        else
        {
            played = false;
        }

    }
}
