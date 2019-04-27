using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
