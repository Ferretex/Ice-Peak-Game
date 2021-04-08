using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterAuraObject : MonoBehaviour
{

    Tilemap tm;
    GridLayout gridLayout;

    public Tilemap frozenTm;

    public TileBase waterSurfaceTile;
    public TileBase frozenSurfaceTile;

    void Start()
    {
        tm = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();
        
    }

    public void OnWaterEnterAura(bool auraType, Transform groundChecker, Transform headChecker , Transform leftChecker, Transform rightChecker)
    {

        if (!auraType) //Cold
        {
            //tm.color = new Color(0f, 1f, 1f, 1f);

            if(tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == waterSurfaceTile)
            {

                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozenSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), frozenSurfaceTile);

                if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                }

                if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                }
                
            }       
                    //Get tile position with ground checker, translate to cell positon, check if its a surface tile
                    //If yes, change it's sprite to frozen and activate the collider for the invisible tile.

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == waterSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), frozenSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), frozenSurfaceTile);

                if (tm.GetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                }

                if (tm.GetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                }
                
            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == waterSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozenSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position), frozenSurfaceTile);

                if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                }

                if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                }

            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == waterSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozenSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), frozenSurfaceTile);

                if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0, 0)), frozenSurfaceTile);
                }

                if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0, 0))) == waterSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0, 0)), frozenSurfaceTile);
                }

            }

        }
        else //Hot
        {
            //tm.color = new Color(1f, 0f, 0f, 1f);

            if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position)) == frozenSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(groundChecker.position), waterSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position), null);

                if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(0.32f, 0, 0)), null);
                }

                if (tm.GetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(groundChecker.position + new Vector3(-0.32f, 0, 0)), null);
                }
            }
                    //Same but in reverse

            if (tm.GetTile(gridLayout.WorldToCell(headChecker.position)) == frozenSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(headChecker.position), waterSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position), null);

                if (tm.GetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(0.32f, 0, 0)), null);
                }

                if (tm.GetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(headChecker.position + new Vector3(-0.32f, 0, 0)), null);
                }

            }

            if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position)) == frozenSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(leftChecker.position), waterSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position), null);

                if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(0.32f, 0, 0)), null);
                }

                if (tm.GetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(leftChecker.position + new Vector3(-0.32f, 0, 0)), null);
                }

            }

            if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position)) == frozenSurfaceTile)
            {
                tm.SetTile(gridLayout.WorldToCell(rightChecker.position), waterSurfaceTile);
                frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position), null);

                if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(0.32f, 0, 0)), null);
                }

                if (tm.GetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0, 0))) == frozenSurfaceTile)
                {
                    tm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0, 0)), waterSurfaceTile);
                    frozenTm.SetTile(gridLayout.WorldToCell(rightChecker.position + new Vector3(-0.32f, 0, 0)), null);
                }

            }
        }

        //Debug.Log((gridLayout.WorldToCell(groundChecker.position)));
    }

    private void OnTriggerEnter2D(Collider2D collision)   //player drop in water sfx
    {     
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.5f, 1.5f);

        if(!audioSource.isPlaying)
        audioSource.PlayOneShot(audioSource.clip, 5f);
    }
}
