using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceWallScript : MonoBehaviour
{

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap frozenTm;

    public TileBase topFrozen;
    public TileBase bottomFrozen;
    public TileBase bottomMelted;

    void Start()
    {
        tm = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();

    }

    public void OnIceWallEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {

        if (!auraType) //Cold
        {
            //tm.color = new Color(0f, 1f, 1f, 1f);

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == bottomMelted)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), bottomFrozen);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0, 0.32f, 0)), topFrozen);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == bottomMelted)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), bottomFrozen);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0, 0.32f, 0)), topFrozen);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == bottomMelted)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), bottomFrozen);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0, 0.32f, 0)), topFrozen);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == bottomMelted)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), bottomFrozen);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0, 0.32f, 0)), topFrozen);
            }

        }
        else //Hot
        {
            //tm.color = new Color(1f, 0f, 0f, 1f);

            //Top half

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == topFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0, -0.32f, 0)), bottomMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == topFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0, -0.32f, 0)), bottomMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == topFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0, -0.32f, 0)), bottomMelted);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == topFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0, -0.32f, 0)), bottomMelted);
            }

            //Bottom Half

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == bottomFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), bottomMelted);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0, 0.32f, 0)), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == bottomFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), bottomMelted);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0, 0.32f, 0)), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == bottomFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), bottomMelted);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0, 0.32f, 0)), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == bottomFrozen)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), bottomMelted);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0, 0.32f, 0)), null);
            }

        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }
}
