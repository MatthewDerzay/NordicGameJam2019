﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollision : MonoBehaviour
{

    private PlayerSpawner spawner;

    private void Start() {
        spawner = GameObject.Find("PlayerSpawn").GetComponent<PlayerSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Hazard"))
        {
            Destroy(other.gameObject);
            // reduce score
            // death animation
            Destroy(gameObject);
            spawner.Spawn();
        }
        if(other.gameObject.CompareTag("GroupHazard"))
        {
            Destroy(other.transform.parent.gameObject);
            // reduce score
            // death animation
            Destroy(gameObject);
            spawner.Spawn();
        }
    }
}
