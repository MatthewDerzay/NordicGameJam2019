using System.Collections;
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
        yield return new WaitForSeconds(.75f);
        Destroy(gameObject);
    }
}
