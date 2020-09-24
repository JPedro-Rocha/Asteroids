using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoNave : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movespeed = 1f;
    [SerializeField] float rotationspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationspeed * Time.fixedDeltaTime);
        rb.AddForce(transform.up * movespeed * Input.GetAxis("Vertical"));
        /*if (Input.GetAxis("Vertical") == 1)
        {
            rb.transform.position += transform.up * Time.deltaTime * movespeed;
        }
        */
    }
}
