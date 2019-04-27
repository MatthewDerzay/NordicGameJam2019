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
    private Renderer renderer;
    private float movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        movement = 0;
        CheckIsGrounded();
    }

    void FixedUpdate()
    {
        movement = 0;
        bool jump = false;
        CheckIsGrounded();
        Debug.Log(isGrounded);

        if(Input.GetKey(KeyCode.A))
        {
            movement = -1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            movement = 1;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        animator.SetFloat("Speed", Mathf.Abs(movement * speed));
        rb.velocity = new Vector2(movement, 0) * speed;
    }

    void CheckIsGrounded()
    {
        isGrounded = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 1), playerMask) || Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 1), playerMask);
        Debug.Log(renderer.bounds.size);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }
}
