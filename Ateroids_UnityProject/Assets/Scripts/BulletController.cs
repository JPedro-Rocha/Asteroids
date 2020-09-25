using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
        //GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
        GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D asteroid)//bala bate em asteroide
    {
        Destroy(gameObject);
    }
}
