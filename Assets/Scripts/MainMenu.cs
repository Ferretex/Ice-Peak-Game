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

    void Start()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    void Update()
    {
        if (Screen.fullScreen == true)
        {
            canvasScalar.scaleFactor = 2.5f;
        } else
        {
            canvasScalar.scaleFactor = 1f;
        }
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
