using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public GameObject pauseFirstButton;

    public Canvas canvasScalar;

    private Vector2 res;

    void Start()
    {
        res = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (res.x < 704)
        {
            canvasScalar.scaleFactor = 0.5f;
        }
        else if (res.x > 704 && res.x < 1056)
        {
            canvasScalar.scaleFactor = 1f;
        }
        else if (res.x > 1056 && res.x < 1408)
        {
            canvasScalar.scaleFactor = 1.5f;
        }
        else if (res.x > 1408 && res.x < 1760)
        {
            canvasScalar.scaleFactor = 2f;
        }
        else if (res.x > 1760 && res.x < 2112)
        {
            canvasScalar.scaleFactor = 2.5f;
        }

        if (res.x != Screen.width || res.y != Screen.height)
        {
            // do your stuff

            res.x = Screen.width;
            res.y = Screen.height;
        }
        //Debug.Log("Screen Resolution: " + res);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
