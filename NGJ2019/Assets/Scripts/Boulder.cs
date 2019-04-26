using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyBoulder");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator DestroyBoulder()
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.CompareTag("Ground"))
        //{

        //}
    //}
}
