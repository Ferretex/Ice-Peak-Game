using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceSpikeMelted : MonoBehaviour
{

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

    public void OnIceSpikesMeltedEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {
        if (!auraType) //Cold
        {
            Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == melted)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozen);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == melted)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), frozen);
            }

            if (frozenTm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == melted)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozen);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == melted)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozen);
            }

        }
        else //Hot
        {
            //Code in IceSpikes.cs
        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }


}
