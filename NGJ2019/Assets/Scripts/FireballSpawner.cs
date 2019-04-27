using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireball;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        GameObject go = Instantiate(fireball, transform.position, transform.rotation);
        go.transform.parent = gameObject.transform;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
