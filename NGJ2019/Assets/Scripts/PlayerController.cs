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
    private PlayerSpawner spawner;
    private PolygonCollider2D polyCollider;
    private float movement;
    private bool control;
    private bool killed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        spawner = GameObject.Find("PlayerSpawn").GetComponent<PlayerSpawner>();
        polyCollider = GetComponent<PolygonCollider2D>();
        movement = 0;
        control = true;
        CheckIsGrounded();
        killed = false;
    }

    void FixedUpdate()
    {
        if(!control)
        {
            return;
        }

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

        if(Input.GetKey(KeyCode.Space))
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
        float leftSide = transform.position.x - rend.bounds.size.x/2 + .05f;
        float rightSide = transform.position.x + rend.bounds.size.x/2 - .05f;
        float bottom = transform.position.y - rend.bounds.size.y/2 - 0.1f;
        isGrounded = Physics2D.Linecast(new Vector2(leftSide, transform.position.y), new Vector2(leftSide, bottom), playerMask) || Physics2D.Linecast(new Vector2(rightSide, transform.position.y), new Vector2(rightSide, bottom), playerMask);
    }

    public void Death()
    {
        StartCoroutine(DeathSequence());
    }

    public IEnumerator DeathSequence()
    {
        if(!killed)
        {
            PlayerSound.instance.PlayOof();
            GameManager.instance.AddDeath();
            killed = true;
            control = false;
            animator.enabled = false;
            rend.sortingOrder = 1;
            rb.freezeRotation = false;
            polyCollider.enabled = false;
            rb.AddTorque(80);
            rb.gravityScale = 5;
            rb.velocity = new Vector2(0, jumpForce * 4);
            yield return new WaitForSeconds(1f);
            spawner.Spawn();
            control = true;
            yield return new WaitForSeconds(4f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Goal"))
        {
            LevelManager.instance.NextScene();
        }
    }
}
