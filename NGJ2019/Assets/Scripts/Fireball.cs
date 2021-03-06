﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("DestroyFireball");
        foreach (GameObject hazard in GameObject.FindGameObjectsWithTag("Hazard"))
        {
            Physics2D.IgnoreCollision(hazard.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = -transform.right;

        rb.AddForce(movement * speed);
    }

    IEnumerator DestroyFireball()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetBool("Dead", true);
        StartCoroutine("DestroyFireballOnCollision");
    }

    IEnumerator DestroyFireballOnCollision()
    {
        yield return new WaitForSeconds(.15f);
        gameObject.tag = "Untagged";
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        yield return new WaitForSeconds(.35f);
        Destroy(gameObject);
    }
}
