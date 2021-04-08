using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public GameObject hero, pauseMenu;

    public TMPro.TextMeshProUGUI Text;
    public string[] Sections;
    private int index;
    public float speed;

    public Collider2D Activator;
    public Image TextBox;

    bool isPaused = false;
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
        Debug.Log("Dialog Start");

        TextBox.enabled = true;

        hero.GetComponent<HeroScript>().DialogPause(true);

        foreach (string line in Sections)
        {
            
            foreach (char letter in Sections[index].ToCharArray())
            {
                isPaused = pauseMenu.GetComponent<PauseMenu>().IsPaused();

                if (isPaused == true)
                {
                    TextBox.enabled = false;
                    Text.enabled = false;
                    while(isPaused == true)
                    {
                        isPaused = pauseMenu.GetComponent<PauseMenu>().IsPaused();
                        yield return null;
                    }
                    TextBox.enabled = true;
                    Text.enabled = true;
                }

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
        hero.GetComponent<HeroScript>().DialogPause(false);

        Activator.enabled = false; //prevents the box from being activated twice
        TextBox.enabled = false;

        Debug.Log("Dialog End");
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            StartCoroutine(Type());

        }
    }
}
