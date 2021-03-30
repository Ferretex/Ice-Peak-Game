using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu, optionsMenu;

    public GameObject pauseFirstButton, optionsMenuFirstButton;

    public Canvas canvasScalar;

    private Vector2 res;

    [SerializeField] Transform respawnPoint;

    [SerializeField] GameObject player;

    public Transform[] crates;

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
        else if (res.x >= 704 && res.x < 1056)
        {
            canvasScalar.scaleFactor = 1f;
        }
        else if (res.x >= 1056 && res.x < 1408)
        {
            canvasScalar.scaleFactor = 1.5f;
        }
        else if (res.x >= 1408 && res.x < 1760)
        {
            canvasScalar.scaleFactor = 2f;
        }
        else if (res.x >= 1760 && res.x < 2112)
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
        CloseMainMenu();
        CloseOptions();
        Time.timeScale = 1f;
        isPaused = false;
        
    }

    void Pause()
    {
        OpenMainMenu();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OpenMainMenu()
    {
        pauseMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(optionsMenuFirstButton);
    }

    public void CloseMainMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void ResetLevel()
    {
        player.transform.position = respawnPoint.position;
        
        foreach(Transform pos in crates)
        {
            pos.GetComponent<CrateAuraObject>().ResetCrate();
        }

        Resume();
    }
}
