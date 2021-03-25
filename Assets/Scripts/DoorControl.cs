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
        }
    }

    public void OnButtonUp()
    {
        if (transform.position.y >= closeHeight)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }
    }
}
