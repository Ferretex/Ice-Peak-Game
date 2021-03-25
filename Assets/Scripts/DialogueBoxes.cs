using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxes : MonoBehaviour
{
    public BoxCollider2D Activator;
    public SpriteRenderer TextBox;

    void Start()
    {
        TextBox.enabled = false;
    }
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TextBox.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col2)
    {
        if(col2.gameObject.tag == "Player")
        {
            Activator.enabled = false; //prevents the box from being activated twice
            TextBox.enabled = false;
        }
    }
}
