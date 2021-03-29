using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceSpikes : MonoBehaviour
{

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap meltedTm;

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
            // Code in IceSpikesMelted.cs
        }
        else //Hot
        {

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(groundChecker.position), melted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(headChecker.position), melted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(leftChecker.position), melted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(rightChecker.position), melted);
                
            }

        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }


}