using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWallControl : MonoBehaviour
{
    public float openX, closeX;

    bool played = true;

    public void OnButtonDown()
    {

        if (openX >= 0)
        {
            if (transform.position.x <= openX)
            {
                transform.Translate(Vector2.right * Time.deltaTime);

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
            if (transform.position.x > openX)
            {
                transform.Translate(-Vector2.right * Time.deltaTime);

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
        Debug.Log("Slide Wall Up");
        if (openX >= 0)
        {
            if (transform.position.x >= closeX)
            {
                transform.Translate(Vector2.left * Time.deltaTime);

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
            if (transform.position.x < closeX)
            {
                transform.Translate(-Vector2.left * Time.deltaTime);

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
