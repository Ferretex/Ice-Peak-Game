using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu, galleryTemp, optionsMenu;

    public GameObject mainMenuFirstButton, galleryTempFirstButton, optionsMenuFirstButton;

    public Canvas canvasScalar;

    private Vector2 res;

    void Start()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);

        res = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if(res.x < 704)
        {
            canvasScalar.scaleFactor = 0.5f;
        }
        else if(res.x >= 704 && res.x < 1056)
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
        }else if (res.x >= 1760 && res.x < 2112)
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

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(optionsMenuFirstButton);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void OpenGalleryTemp()
    {
        galleryTemp.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(galleryTempFirstButton);
    }

    public void CloseGalleryTemp()
    {
        galleryTemp.SetActive(false);
    }

}
