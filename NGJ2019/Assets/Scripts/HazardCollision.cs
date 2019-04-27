using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollision : MonoBehaviour
{

    private PlayerController controller;

    private void Start() {
        controller = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Hazard"))
        {
            Destroy(other.gameObject);
            // reduce score
            controller.Death();
        }
        if (other.gameObject.CompareTag("GroupHazard"))
        {
            Destroy(other.transform.parent.gameObject);
            // reduce score
            controller.Death();
        }
    }
}
