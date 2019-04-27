using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public float total = 5;
    public LayerMask groundMask;
    public GameObject boulder;

    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < total)
        {
            if (Physics2D.Linecast(transform.position, transform.position - Vector3.up * 4, groundMask))
            {
                GameObject go = Instantiate(boulder, transform.position, transform.rotation);
                go.transform.parent = gameObject.transform;
                counter += 1;
            }
        }   
    }
}
