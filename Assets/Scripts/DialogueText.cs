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
    private int counter = 0;
    public Collider2D Activator;
    public Image TextBox;
    private float WaitTime = 0.001f;
    bool DialogActivated = false;

    bool isPaused = false;
    void Start()
    {
        index = 0;
        TextBox.enabled = false;
        Text.enabled = false;
       
    }
     IEnumerator Type()
   {

        Debug.Log("Dialog Start");


        TextBox.enabled = true;
        Text.enabled = true;
        Activator.enabled = false; //prevents the box from being activated twice
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
                    hero.GetComponent<HeroScript>().DialogPause(true);
                    TextBox.enabled = true;
                    Text.enabled = true;
                    
                }

                Text.text += letter;//display text
                     yield return new WaitForSecondsRealtime(speed);//text speed
            }
          
             while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
            Text.text = "";
            index++; //Goes to the next line after waiting for the line to be read
        }
        hero.GetComponent<HeroScript>().DialogPause(false);

        TextBox.enabled = false;
        Text.enabled = false;
        Debug.Log("Dialog End");
    }
    IEnumerator Skip()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && counter == 1) //Checks if space is held down & if dialogue has been triggered
            {
                yield return new WaitForSecondsRealtime(WaitTime);
                speed = .001f;
                counter++;
                Debug.Log("Skipped");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && counter == 2)
            {
                speed = .03f;
                counter--;
                Debug.Log("Next Line");
            }     
    }
    private void Update() 
    {   
            if (Input.GetKeyDown(KeyCode.Space) && TextBox.enabled == true)
            {
                StartCoroutine(Skip());
            } 
    }
 
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && DialogActivated == false)
        {
            Activator.enabled = false;
            counter++;
            StartCoroutine(Type());
        }
    }
   

}
