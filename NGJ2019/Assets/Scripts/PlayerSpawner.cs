using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    public void Spawn()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
