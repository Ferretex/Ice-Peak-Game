using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public float openHeight, closeHeight;

    bool played = true;

    public void OnButtonDown()
    {

        if (openHeight >= 0)
        {
            if (transform.position.y <= openHeight)
            {
                transform.Translate(Vector2.up * Time.deltaTime);

                AudioSource audioSource = GetComponent<AudioSource>();  //door open sfx
                if (played == false)
                {
                    audioSource.PlayOneShot(audioSource.clip, 2f);
                    played = true;
                }

            }
            else
            {
                played = false;
            }
        }
        else
        {
            if (transform.position.y > openHeight)
            {
                transform.Translate(-Vector2.up * Time.deltaTime);

                AudioSource audioSource = GetComponent<AudioSource>();  //door open sfx
                if (played == false)
                {
                    audioSource.PlayOneShot(audioSource.clip, 2f);
                    played = true;
                }

            }
            else
            {

            }

        }
    }

    public void OnButtonUp()
    {

        if(openHeight >= 0)
        {
            if (transform.position.y >= closeHeight)
            {
                transform.Translate(Vector2.down * Time.deltaTime);

                AudioSource audioSource = GetComponent<AudioSource>();   //door shut sfx
                if (played == false)
                {
                    audioSource.pitch = Random.Range(0.5f, 1f);
                    audioSource.PlayOneShot(audioSource.clip, 2f);
                    played = true;
                }

            }
            else
            {
                played = false;
            }
        }
        else
        {
            if (transform.position.y < closeHeight)
            {
                transform.Translate(-Vector2.down * Time.deltaTime);

                AudioSource audioSource = GetComponent<AudioSource>();   //door shut sfx
                if (played == false)
                {
                    audioSource.pitch = Random.Range(0.5f, 1f);
                    audioSource.PlayOneShot(audioSource.clip, 2f);
                    played = true;
                }

            }
            else
            {
                played = false;
            }
        }
        

    }
}
