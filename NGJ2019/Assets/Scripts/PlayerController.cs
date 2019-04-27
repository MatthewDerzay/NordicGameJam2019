using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int speed = 1;
    public float jumpForce = 1;
    private bool isGrounded;
    public LayerMask playerMask;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer rend;
    private float movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        movement = 0;
        CheckIsGrounded();
    }

    void FixedUpdate()
    {
        movement = 0;
        CheckIsGrounded();

        if(!isGrounded)
        {
            if(rb.velocity.y <= 0)
            {
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsJumping", false);
            }
        } else 
        {
            animator.SetBool("IsFalling", false);
        }

        if(Input.GetKey(KeyCode.A))
        {
            movement = -speed;
            rend.flipX = true;
        }

        if(Input.GetKey(KeyCode.D))
        {
            movement = speed;
            rend.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(movement * speed));
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    void CheckIsGrounded()
    {
        float leftSide = transform.position.x - rend.bounds.size.x/2;
        float rightSide = transform.position.x + rend.bounds.size.x/2;
        float bottom = transform.position.y - rend.bounds.size.y/2 - 0.1f;
        isGrounded = Physics2D.Linecast(new Vector2(leftSide, transform.position.y), new Vector2(leftSide, bottom), playerMask) || Physics2D.Linecast(new Vector2(rightSide, transform.position.y), new Vector2(rightSide, bottom), playerMask);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }
}
