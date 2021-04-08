using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryStorage : MonoBehaviour
{

    static bool[] collected = new bool[] { false, false, false, false };

    public void UnlockPhoto(int imgID)
    {
        collected[imgID] = true;
    }

    public bool[] ImportCollected()
    {
        return collected;
    }
}
