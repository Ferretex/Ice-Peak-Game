using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class GalleryMenu : MonoBehaviour
{
    public GameObject galleryStorage;

    public GameObject galleryMenu, selectedMenu;

    public GameObject galleryMenuFirstButton, selectedMenuFirstButton;

    public Image selectedPhoto;

    public Sprite defaultImage;

    public Image[] pictures;

    bool[] collected;

    void Start()
    {
        collected = galleryStorage.GetComponent<GalleryStorage>().ImportCollected();

        int i = 0;
        foreach(Image col in pictures)
        {
            if(collected[i] != true)
            {
                col.sprite = defaultImage;
            }
            i++;
        }
    }

    public void OpenSelectedImage()
    {
        selectedPhoto.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        selectedMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(selectedMenuFirstButton);
    }

    public void CloseSelectedImage()
    {
        selectedMenu.SetActive(false);
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

}
