using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceSpikes : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap frozenTm;

    public TileBase frozen;
    public TileBase melted;

    void Start()
    {
        tm = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();

    }

    public void OnIceSpikesEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {
        if (!auraType) //Cold
        {

            //if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == melted)
            //{
            //    tm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozen);
            //}

            //if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == melted)
            //{
            //    tm.SetTile(gridLayout.WorldToCell(headChecker.position), frozen);
            //}

            //if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == melted)
            //{
            //    tm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozen);
            //}

            //if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == melted)
            //{
            //    tm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozen);
            //}

        }
        else //Hot
        {

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), melted);

            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), melted); 
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), melted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), melted);
            }

        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }

    //private void OnTriggerEnter2D(Collider2D col)       //Set the player's position back to the respawn position
    //{
    //    if (col.transform.CompareTag("Player"))
    //    {
    //        col.transform.position = respawnPoint.position;
    //    }

    //}

}