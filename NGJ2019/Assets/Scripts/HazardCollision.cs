using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollision : MonoBehaviour
{

    private PlayerSpawner spawner;

    private void Start() {
        spawner = GameObject.Find("PlayerSpawn").GetComponent<PlayerSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(other.gameObject);
        // reduce score
        // death animation
        Destroy(gameObject);
        spawner.Spawn();
    }
}
