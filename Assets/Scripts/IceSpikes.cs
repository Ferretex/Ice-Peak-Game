using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceSpikes : MonoBehaviour
{

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap meltedTm;

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

    public void OnIceSpikesEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {
        if (!auraType) //Cold
        {
            // Code in IceSpikesMelted.cs
        }
        else //Hot
        {


            //Bottom
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(groundChecker.position), meltedBottom);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(headChecker.position), meltedBottom);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(leftChecker.position), meltedBottom);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenBottom)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(rightChecker.position), meltedBottom);  
            }

            //Top
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenTop)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(groundChecker.position), meltedTop);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenTop)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(headChecker.position), meltedTop);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenTop)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(leftChecker.position), meltedTop);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenTop)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(rightChecker.position), meltedTop);
            }

            //Right
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenRight)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(groundChecker.position), meltedRight);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenRight)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(headChecker.position), meltedRight);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenRight)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(leftChecker.position), meltedRight);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenRight)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(rightChecker.position), meltedRight);
            }

            //Left
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(groundChecker.position), meltedLeft);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(headChecker.position), meltedLeft);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(leftChecker.position), meltedLeft);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenLeft)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                meltedTm.SetTile(gridLayout.WorldToCell(rightChecker.position), meltedLeft);
            }

        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }


}