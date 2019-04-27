using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public float speed;
    public float distance;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float counter = 0;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        direction = -transform.right;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = direction;
        rb.AddForce(movement * speed);
        counter += Time.deltaTime;

        if(distance < counter)
        {
            direction = -direction;
            counter = 0;
            if(sr.flipX == false)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
            rb.velocity = Vector3.zero;
        }
    }
}
