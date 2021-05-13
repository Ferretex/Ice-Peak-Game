using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public static int DeathCount = 0;
    public TMPro.TextMeshProUGUI Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Deaths: " + DeathCount; 
    }
}
