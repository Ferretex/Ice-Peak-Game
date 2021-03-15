using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    float x = 0;
    float pos;

    private void Start()
    {
        pos = transform.position.x;
    }
    private void Update()
    {
        x += 0.02f;
        pos = pos + Mathf.Sin(x);

        transform.Translate(Vector3.up * Mathf.Sin(x) * 0.002f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HeroScript>().GetArtifact();
            GetComponent<SpriteRenderer>().sprite = null;
        }
        
    }

}
