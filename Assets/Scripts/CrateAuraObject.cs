using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateAuraObject : MonoBehaviour
{

    SpriteRenderer sr;

    Rigidbody2D rb;

    public PhysicsMaterial2D lowFriction;
    public PhysicsMaterial2D highFriction;
    public LayerMask groundLayer;

    bool isGrounded = false;    //Ground Chaeck Variables
    public Transform isGroundedChecker;
    public float checkGroundRadius;

    Vector3 respawnPoint;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        respawnPoint = rb.position;
    }

    void Update()
    {
        SlopeCheck();
        CheckIfGrounded();

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetCrate();
        }
    }

    void SlopeCheck()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, new Vector2(-1, -1), .2f, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, new Vector2(1, -1), .2f, groundLayer);

        if ((hitLeft.collider != null && Mathf.Abs(hitLeft.normal.x) > 0.1f && Mathf.Abs(hitLeft.normal.x) < 0.9f) ||
            (hitRight.collider != null && Mathf.Abs(hitRight.normal.x) > 0.1f && Mathf.Abs(hitRight.normal.x) < 0.9f) && isGrounded)
        {
            Debug.Log("SlopeDetected");

            rb.sharedMaterial = lowFriction;

            if (rb.velocity.y > 0)
            {
                rb.gravityScale = 0.5f;
            }
            else
            {
                rb.gravityScale = 2;
            }
            
            

        }
        else
        {
            rb.sharedMaterial = default;
            rb.gravityScale = 1;
        }
    }

    void CheckIfGrounded()  //Checks if the player is on the ground
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        //Empty object placed under the player, if the collider overlaps with a ground object it sets is grounded to 1

        if (collider != null)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }

    public void OnCrateEnterAura(bool auraType)
    {
        /*
        if (!auraType)
        {
            sr.color = new Color(0f, 1f, 1f, 1f);
            rb.sharedMaterial = lowFriction;
        } else
        {
            sr.color = new Color(1f, 0f, 0f, 1f);
            rb.sharedMaterial = default;
        }
        */
    }

    public void ResetCrate()
    {
        rb.position = respawnPoint;
    }
}
