using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceCrystalScript : MonoBehaviour
{
    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap frozenTm;

    public TileBase frozenBL;
    public TileBase frozenBR;
    public TileBase frozenTL;
    public TileBase frozenTR;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();
    }

    public void OnIceCrystalEnterAura(bool auraType, Transform groundChecker, Transform headChecker, Transform leftChecker, Transform rightChecker)
    {

        if (auraType) //hot
        {
            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenBL)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenBL)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenBL)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenBL)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0.32f, 0)), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenBR)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenBR)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenBR)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenBR)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0f, 0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0.32f, 0)), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenTL)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, -0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenTL)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, -0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenTL)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, -0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenTL)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, -0.32f, 0)), null);
            }

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenTR)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, -0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenTR)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, -0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenTR)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, -0.32f, 0)), null);
            }
            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenTR)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0f, -0.32f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0f, 0)), null);
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, -0.32f, 0)), null);
            }
        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }
}
