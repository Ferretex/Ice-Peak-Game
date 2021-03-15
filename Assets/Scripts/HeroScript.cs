using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroScript : MonoBehaviour
{

    Rigidbody2D rb;             
    Collider2D cl;
    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D highFriction;


    public float speed;             //Movement Variables
    public float acceleration;
    float moveBy = 0;
    private bool facingRight = true;

    public float jumpPower;         //Jump Variables
    bool isJumping = false;
    public float jumpTime;
    float jumpTimeCounter;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded = false;        //Ground Chaeck Variables
    public Transform isGroundCheckerLeft;
    public Transform isGroundCheckerRight;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    bool inWater = false;
    public LayerMask waterLayer;

    public Transform respawnPoint;

    bool auraActivated = false;     //Tempature ring activator
    bool auraToggle = false;        //Flase = Cold, True = Hot
    public Transform auraCircle;
    public float auraRadius;
    Collider2D[] results;
    public SpriteRenderer auraVisual;

    public Transform isBottomChecker;
    public Transform isHeadChecker;
    public Transform isLeftChecker;
    public Transform isRightChecker;

    public Animator animator;

    bool hasArtifact = false;       //Before the player gets the artifact

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       //Get the rigid body  and collider component
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
            
        } else if (!isGrounded)         //If jumping but not holding a direction, movement stops slower
        {
            moveBy -= moveBy * 0.025f;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);

        } else
        {
            moveBy = 0;
        }

        animator.SetFloat("Speed", Mathf.Abs(moveBy));  //If speed < 0 the run animation is played

        if(moveBy > 0 && !facingRight)  //Turn the character around
        {
            Flip();
        } else if(moveBy < 0 && facingRight)
        {
            Flip();
        }
        
    }

    void Flip()     //Turn the character around
    {
        facingRight = !facingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void SlopeCheck()       //Checks if the player hits any slopes
    {
        RaycastHit2D hitBottomLeft = Physics2D.Raycast(transform.position, new Vector2(-1,-1), .5f, groundLayer);  //Raycast from the corners of the palyer
        RaycastHit2D hitBottomRight = Physics2D.Raycast(transform.position, new Vector2(1,-1), .5f, groundLayer);
        RaycastHit2D hitTopLeft = Physics2D.Raycast(transform.position, new Vector2(-1, 1), .5f, groundLayer);
        RaycastHit2D hitTopRight = Physics2D.Raycast(transform.position, new Vector2(1, 1), .5f, groundLayer);

        //Debug.Log("is groudned: " + isGrounded);

        if ((hitBottomLeft.collider != null && Mathf.Abs(hitBottomLeft.normal.x) > 0.1f) || (hitBottomRight.collider != null && Mathf.Abs(hitBottomRight.normal.x ) > 0.1f)  ||
            (hitTopLeft.collider != null && Mathf.Abs(hitTopLeft.normal.x) > 0.1f) || (hitTopRight.collider != null && Mathf.Abs(hitTopRight.normal.x) > 0.1f) && !inWater)  //If it his a collider and not in water
        {
            //Debug.Log("SlopeDetected");

            rb.sharedMaterial = noFriction;
        } 
        else
        {
            rb.sharedMaterial = default;
        }
    }

    void Jump()         //Basic Jump
    {
        float x = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Jump");      //Checks for WASD, aroow Keys or space bar inputs
        if(x == 1 && (isGrounded || isJumping || inWater))   //if input and the player is grounded, is juming or is in water
        {
            isJumping = true;       //sets isJumping to true

            if(jumpTimeCounter > 0)     //unitll the counter gets to zero, isJumping is true and the player can hold to determine the height of the jump
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
            jumpTimeCounter = jumpTime;     //Resets jump counter
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
        Collider2D colliderLeft = Physics2D.OverlapCircle(isGroundCheckerLeft.position, checkGroundRadius, groundLayer);        //Empty to the left and right of the player to check for ground
        Collider2D colliderRight = Physics2D.OverlapCircle(isGroundCheckerRight.position, checkGroundRadius, groundLayer);

        //Empty object placed under the player, if the collider overlaps with a ground object it sets is grounded to 1

        if (colliderLeft != null || colliderRight != null)
        {
            isGrounded = true;

            animator.SetBool("JumpUp", false);
            animator.SetBool("JumpDown", false);

        } else
        {
            isGrounded = false;
        }
    }

    void CheckIfWater()     //Checks if in water
    {
        Collider2D colliderLeft = Physics2D.OverlapCircle(isGroundCheckerLeft.position, checkGroundRadius, waterLayer);
        Collider2D colliderRight = Physics2D.OverlapCircle(isGroundCheckerRight.position, checkGroundRadius, waterLayer);

        //Debug.Log(collider.name);

        if (colliderLeft != null || colliderRight != null)
        {
            //Debug.Log("InTheWater");
            inWater = true;
        } else
        {
            inWater = false;
        }
    }

    void activateAura()     //Controls for activating ang toggleing the aura
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
        {
            auraActivated = true;
            auraToggle = false;

            auraVisual.color = new Color(0f, 1f, 1f, 0.5f);
        } else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Z))
        {
            auraActivated = true;
            auraToggle = true;

            auraVisual.color = new Color(1f, 0.25f, 0f, 0.5f);
        } else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.R))
        {
            auraActivated = false;

            auraVisual.color = new Color(0f, 0f, 0f, 0f);
        }
    }

    void Aura() //Arura controls
    {
        results = new Collider2D[20];
        Physics2D.OverlapCircleNonAlloc(auraCircle.position, auraRadius, results);      //gets all colliders in aura radius


        auraVisual.transform.Rotate(new Vector3(0, 0, -0.2f));      //Spins aura
        
        
        foreach (Collider2D col in results)     //For every collider detected
        {
            if (col != null)
            {
                //Debug.Log(col.transform.position);

                switch (col.tag)        //If the tag matches an aura object, it goes into the switch statement and calls the funtion at that object
                {
                    case "Crate": col.GetComponent<CrateAuraObject>().OnCrateEnterAura(auraToggle); break;

                    case "Water": col.GetComponent<WaterAuraObject>().OnWaterEnterAura(auraToggle, isBottomChecker, isHeadChecker, isLeftChecker, isRightChecker); break;

                    case "IceWall": col.GetComponent<IceWallScript>().OnIceWallEnterAura(auraToggle, isBottomChecker, isHeadChecker, isLeftChecker, isRightChecker); break;
                }

            }
        }
            
    }

    public void MoveRespawnPoint()      //Moves respwan point to last safe location
    {
        respawnPoint.position = new Vector2(rb.position.x, rb.position.y);     
    }

    public void GetArtifact()       // First time collecting aritfact
    {
        hasArtifact = true;
    }
}


