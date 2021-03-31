using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceSpikeMelted : MonoBehaviour
{

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap frozenTm;

    public TileBase frozenBottom;
    public TileBase meltedBottom;

    public TileBase frozenTop;
    public TileBase meltedTop;

    public TileBase frozenRight;
    public TileBase meltedRight;

    public TileBase frozenLeft;
    public TileBase meltedLeft;

    void Start()
    {
        tm = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();

    }

    public void OnIceSpikesMeltedEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {
        if (!auraType) //Cold
        {
            //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));

            //Bottom
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == meltedBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozenBottom);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == meltedBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), frozenBottom);
            }

            if (frozenTm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == meltedBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozenBottom);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == meltedBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozenBottom);
            }

            //Top
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == meltedTop)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozenTop);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == meltedTop)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), frozenTop);
            }

            if (frozenTm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == meltedTop)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozenTop);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == meltedTop)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozenTop);
            }

            //Right
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == meltedRight)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozenRight);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == meltedRight)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), frozenRight);
            }

            if (frozenTm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == meltedRight)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozenRight);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == meltedRight)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozenRight);
            }

            //Left
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == meltedLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozenLeft);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == meltedLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), frozenLeft);
            }

            if (frozenTm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == meltedLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozenLeft);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == meltedLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozenLeft);
            }

        }
        else //Hot
        {
            //Code in IceSpikes.cs
        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }


}
