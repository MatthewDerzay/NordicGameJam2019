using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int speed = 1;
    private Rigidbody2D rb;
    public Animator animator;
    private float movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = 0;
    }

    void FixedUpdate()
    {
        movement = 0;

        if(Input.GetKey(KeyCode.A))
        {
            movement = -1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            movement = 1;
        }

        animator.SetFloat("Speed", Mathf.Abs(movement * speed));
        rb.velocity = new Vector2(movement, 0) * speed;
    }
}
