using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerSpawner spawner;

    private void Start() {
        spawner = GameObject.Find("PlayerSpawn").GetComponent<PlayerSpawner>();
        spawner.Spawn();
    }
}
