using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroScript : MonoBehaviour
{

    Rigidbody2D rb;             //Movement Variables
    Collider2D cl;
    public PhysicsMaterial2D friction;
    public float speed;
    public float acceleration;
    float moveBy = 0;
    private bool facingRight = true;

    public float jumpPower;       //Jump Variables
    bool isJumping = false;
    public float jumpTime;
    float jumpTimeCounter;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded = false;    //Ground Chaeck Variables
    public Transform isGroundedChecker;
    public Transform isHeadChecker;
    public Transform isLeftChecker;
    public Transform isRightChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    bool inWater = false;
    public LayerMask waterLayer;

    public Transform respawnPoint;

    bool auraActivated = false; //Tempature ring activator
    bool auraToggle = false;    //Flase = Cold, True = Hot
    public Transform auraCircle;
    public float auraRadius;
    Collider2D[] results;

    public Animator animator;

    public SpriteRenderer auraVisual;

    bool hasArtifact = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       //Get the rigid body component
        cl = GetComponent<BoxCollider2D>();

    }


    // Update is called once per frame
    void Update()
    {
        Move();                                 //Call all functions from the update function
        SlopeCheck();

        Jump();
        BetterJump();

        CheckIfGrounded();
        CheckIfWater();

        if(hasArtifact)
            activateAura();

        if(auraActivated)
            Aura();
    }

    void Move()         //Basic Movement
    {
        float x = Input.GetAxisRaw("Horizontal");       //Checks for WASD and Arrow key inputs
        if(x == 1 ||  x == -1)
        {
            moveBy = rb.velocity.x;


            if (Mathf.Abs(moveBy) < speed)              //Acceleration for normal movement
                moveBy += x * acceleration;
            if (Mathf.Abs(moveBy) > speed)              //If the player hhas suyrpassed max speed by sliding down a slope, it sustains the speed but never increases
                moveBy = x * Mathf.Abs(rb.velocity.x);

            rb.velocity = new Vector2(moveBy, rb.velocity.y);
            
        } else
        {
            moveBy = 0;
        }

        animator.SetFloat("Speed", Mathf.Abs(moveBy));

        if(moveBy > 0 && !facingRight)
        {
            Flip();
        } else if(moveBy < 0 && facingRight)
        {
            Flip();
        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void SlopeCheck()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, new Vector2(-1,-1), .5f, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, new Vector2(1,-1), .5f, groundLayer);

        if ((hitLeft.collider != null && Mathf.Abs(hitLeft.normal.x) > 0.1f && Mathf.Abs(hitLeft.normal.x) < 0.9f) ||
            (hitRight.collider != null && Mathf.Abs(hitRight.normal.x) > 0.1f && Mathf.Abs(hitRight.normal.x) < 0.9f) && isGrounded  && !inWater)
        {
            //Debug.Log("SlopeDetected");

            rb.sharedMaterial = friction;
            rb.gravityScale = 0;

        } 
        else
        {
            rb.sharedMaterial = default;
            rb.gravityScale = 1;
        }
    }

    void Jump()         //Basic Jump
    {
        float x = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Jump");      //Checks for WASD, aroow Keys or space bar inputs
        if(x == 1 && (isGrounded || isJumping || inWater))   //if input and the player was grounded at leaste 0.1 seconds ago
        {
            isJumping = true;

            if(jumpTimeCounter > 0)
            { 
                jumpTimeCounter -= Time.deltaTime;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            } else
            {
                isJumping = false;
            }
        } else
        {
            isJumping = false;
            jumpTimeCounter = jumpTime;
        }
    }

    void BetterJump()   //Better more mario like jump
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;      //Faster falling speed
            animator.SetBool("JumpUp", false);
            animator.SetBool("JumpDown", true);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space) || !Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;   //Slower rising speed
            animator.SetBool("JumpUp", true);
            animator.SetBool("JumpDown", false);
        }
    }

    void CheckIfGrounded()  //Checks if the player is on the ground
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);  
        
        //Empty object placed under the player, if the collider overlaps with a ground object it sets is grounded to 1

        if (collider != null)
        {
            isGrounded = true;

            animator.SetBool("JumpUp", false);
            animator.SetBool("JumpDown", false);

        } else
        {
            isGrounded = false;
        }
    }

    void CheckIfWater()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, waterLayer);

        //Debug.Log(collider.name);

        if (collider != null)
        {
            //Debug.Log("InTheWater");
            inWater = true;
        } else
        {
            inWater = false;
        }
    }

    void activateAura()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Z))
        {
            auraActivated = true;
            auraToggle = false;

            auraVisual.color = new Color(0f, 1f, 1f, 0.5f);
        } else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
        {
            auraActivated = true;
            auraToggle = true;

            auraVisual.color = new Color(1f, 0f, 0f, 0.5f);
        } else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.R))
        {
            auraActivated = false;

            auraVisual.color = new Color(0f, 0f, 0f, 0f);
        }
    }

    void Aura()
    {
        results = new Collider2D[20];
        Physics2D.OverlapCircleNonAlloc(auraCircle.position, auraRadius, results);


        auraVisual.transform.Rotate(new Vector3(0, 0, -0.1f));
        
        
        foreach (Collider2D col in results)
        {
            if (col != null)
            {
                //Debug.Log(col.transform.position);

                switch (col.tag)
                {
                    case "Crate": col.GetComponent<TestAuraObject>().OnCrateEnterAura(auraToggle); break;

                    case "Water": col.GetComponent<WaterAuraObject>().OnWaterEnterAura(auraToggle, isGroundedChecker, isHeadChecker, isLeftChecker, isRightChecker); break;

                    case "IceWall": col.GetComponent<IceWallScript>().OnIceWallEnterAura(auraToggle, isGroundedChecker, isHeadChecker, isLeftChecker, isRightChecker); break;
                }

            }
        }
            
    }

    public void MoveRespawnPoint()
    {
     respawnPoint.position = new Vector2(rb.position.x, rb.position.y);     
    }

    public void GetArtifact()
    {
        hasArtifact = true;
    }
}


