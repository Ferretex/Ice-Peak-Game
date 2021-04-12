using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu, galleryMenu, optionsMenu, levelSelectMenu, galleryStorage;

    public GameObject mainMenuFirstButton, galleryMenuFirstButton, optionsMenuFirstButton, levelSelectMenuFirstButton;

    public Canvas canvasScalar;

    private Vector2 res;

    public GameObject notUnlocked;

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
        if(res.x < 704  || res.y < 384)
        {
            canvasScalar.scaleFactor = 0.5f;
        }
        else if(res.x >= 704 && res.x < 1056 || res.y >= 384 && res.y < 576)
        {
            canvasScalar.scaleFactor = 1f;
        }
        else if (res.x >= 1056 && res.x < 1408 || res.y >= 576 && res.y < 768)
        {
            canvasScalar.scaleFactor = 1.5f;
        }
        else if (res.x >= 1408 && res.x < 1760 || res.y >= 768 && res.y < 960)
        {
            canvasScalar.scaleFactor = 2f;
        }else if (res.x >= 1760 && res.x < 2112 || res.y >= 960 && res.y < 1152)
        {
            canvasScalar.scaleFactor = 2.5f;
        }

        if (res.x != Screen.width || res.y != Screen.height)
        {
            

            res.x = Screen.width;
            res.y = Screen.height;
        }
        //Debug.Log("Screen Resolution: " + res);

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    IEnumerator NotUnlockedMessage()
    {
        notUnlocked.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        notUnlocked.SetActive(false);
    }
    public void LoadSecretLevel()
    {
        if(galleryStorage.GetComponent<GalleryStorage>().SecretLevelUnlocked() == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
        } else
        {
            StartCoroutine(NotUnlockedMessage());
        }
        
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
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

    public void OpenGallery()
    {
        galleryMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(galleryMenuFirstButton);
    }

    public void CloseGallery()
    {
        galleryMenu.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        levelSelectMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(levelSelectMenuFirstButton);
    }

    public void CloseLevelSelect()
    {
        levelSelectMenu.SetActive(false);
    }

}
