using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{

    private static MainMusic _instance;
    void Awake()
    {

        if (!_instance)
        {
            _instance = this;
        }
        else if (this.gameObject.GetComponent<AudioSource>().clip != _instance.gameObject.GetComponent<AudioSource>().clip)
        {
            Destroy(_instance.gameObject);
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

}
