using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;
    public string[] Sections;
    private int index;
    public float speed;
    void Start()
    {
    }
    void Update()
    {
    }
     IEnumerator Type()
   {
       foreach (char letter in Sections[index].ToCharArray())
       {
           Text.text += letter;//display text
           yield return new WaitForSeconds(speed);//text speed
       }
   }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {           
            StartCoroutine(Type());
        }
    }
    public void OnTriggerExit2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Player")
        {
            Debug.Log("Leaving");
            Text.text = "";
        }
    }
}
