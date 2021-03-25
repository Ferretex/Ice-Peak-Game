using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;
    public string[] Sections;
    private int index;
    public float speed;

    public BoxCollider2D Activator;
    public SpriteRenderer TextBox;
    void Start()
    {
        index = 0;
        TextBox.enabled = false;
    }
    void Update()
    {
    }
     IEnumerator Type()
   {
        Debug.Log("Dailog Start");

        TextBox.enabled = true;

        Time.timeScale = 0;

        foreach (string line in Sections)
        {
            foreach (char letter in Sections[index].ToCharArray())
            {
                Text.text += letter;//display text

                yield return new WaitForSecondsRealtime(speed);//text speed
            }
            while (!Input.anyKeyDown)
            {
                yield return null;
            }
            Text.text = "";
            index++;
        }
        Time.timeScale = 1;

        Activator.enabled = false; //prevents the box from being activated twice
        TextBox.enabled = false;

        Debug.Log("Dailog End");
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            

            StartCoroutine(Type());

        }
    }
}
