using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    public void OnButtonDown()
    {
        if(transform.position.y <= 1.28)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
        }
    }

    public void OnButtonUp()
    {
        if (transform.position.y >= 0)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }
    }
}
