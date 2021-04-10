using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Sprite buttonDown;
    public Sprite buttonUp;

    SpriteRenderer buttonSprite;

    public Transform door;

    bool isButtonDown = false;

    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
    }

    void Update()       //Updates call function in the door script
    {
        if (isButtonDown)
        {
            if (door.name.Contains("Door"))
            {
                door.GetComponent<DoorControl>().OnButtonDown();
            }
            else
            {
            door.GetComponent<SlideWallControl>().OnButtonDown();
            }
        }
        else
        {
            if (door.name.Contains("Door"))
            {
                door.GetComponent<DoorControl>().OnButtonUp();
            } else
            {
                door.GetComponent<SlideWallControl>().OnButtonUp();    
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("Button Push");

        buttonSprite.sprite = buttonDown;

        isButtonDown = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   //button press sfx
    {
        //audio for button press
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.5f, 1.5f);

        float randomVolume = Random.Range(0.5f, 1f);
        audioSource.PlayOneShot(audioSource.clip, randomVolume);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("Button Un-Push");

        buttonSprite.sprite = buttonUp;

        isButtonDown = false;
    }

}
