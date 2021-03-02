using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float acceleration;
    float moveBy = 0;

    public float jumpForce;
    public float jumpAccel;
    float jumpBy = 0;
    float jumpReal = 0;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float rememberGroundedFor;
    float lastTimeGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x == 1 ||  x == -1)
        {
            moveBy = rb.velocity.x;

            if (Mathf.Abs(moveBy) < speed)
                moveBy += x * acceleration;
            if (Mathf.Abs(moveBy) > speed)
               moveBy = x * Mathf.Abs(rb.velocity.x);

            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        } else
        {
            moveBy = 0;
        }
        
    }

    void Jump()
    {
        float x = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Jump");
        if(x == 1 && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            if(jumpReal < jumpForce)
            {
                jumpBy += (x * jumpAccel);
                jumpReal += jumpForce - jumpBy;
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpReal);
        } else
        {
            jumpBy = 0;
            jumpReal = 0;
        }
    }
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space) || !Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        } else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time
;            }
            isGrounded = false;
        }
    }
}
