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

    void Update()
    {
        if(isButtonDown)
            door.GetComponent<DoorControl>().OnButtonDown();
        else
            door.GetComponent<DoorControl>().OnButtonUp();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Button Push");

        buttonSprite.sprite = buttonDown;

        isButtonDown = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Button Un-Push");

        buttonSprite.sprite = buttonUp;

        isButtonDown = false;
    }
}
