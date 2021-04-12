using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndMenu : MonoBehaviour
{
    public Canvas canvasScalar;

    private Vector2 res;

    public GameObject backButton;

    void Start()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(backButton);

        res = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (res.x < 704 || res.y < 384)
        {
            canvasScalar.scaleFactor = 0.5f;
        }
        else if (res.x >= 704 && res.x < 1056 || res.y >= 384 && res.y < 576)
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
        }
        else if (res.x >= 1760 && res.x < 2112 || res.y >= 960 && res.y < 1152)
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
}
