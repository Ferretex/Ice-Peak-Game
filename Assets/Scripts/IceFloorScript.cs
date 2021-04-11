using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceFloorScript : MonoBehaviour
{

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap frozenTm;

    public TileBase leftFrozen;
    public TileBase middleFrozen;
    public TileBase rightFrozen;
    public TileBase singleFrozen;
    public TileBase leftMelted;
    public TileBase rightMelted;
    public TileBase singleMelted;

    void Start()
    {
        tm = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();

    }


    public void OnIceFloorEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {

        if (auraType) //Hot
        {
            //tm.color = new Color(1f, 0f, 0f, 1f);

            //Left

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == leftFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), leftMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == leftFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), leftMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == leftFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), leftMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == leftFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), leftMelted);
            }


            //Middle

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == middleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == middleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == middleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == middleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
            }


            //Right

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == rightFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), rightMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == rightFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), rightMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == rightFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), rightMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == rightFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), rightMelted);
            }


            //Single

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == singleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), singleMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == singleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), singleMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == singleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), singleMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == singleFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), singleMelted);
            }

        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }

}
