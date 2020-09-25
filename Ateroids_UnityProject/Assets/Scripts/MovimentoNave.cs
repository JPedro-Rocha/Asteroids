using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoNave : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movespeed = 10f;
    [SerializeField] float rotationspeed = 100f;

    public AudioClip crash;
    public AudioClip shoot;

    public GameObject bullet;
    public Transform firePoint;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { Shoot(); }//atirar
    }

    void FixedUpdate()
    {
        rb.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationspeed * Time.fixedDeltaTime);//rotação
        rb.AddForce(transform.up * movespeed * Input.GetAxis("Vertical"));//movimento vertical

        /*if (Input.GetAxis("Vertical") == 1)
        {
            rb.transform.position += transform.up * Time.deltaTime * movespeed;
        }
        */
    }

    void ShootBullet()
    {
        // spawna bullet
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        // som de tiro
        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
    }

    void OnTriggerEnter2D(Collider2D asteroid)//nave bate em asteroide
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(crash, Camera.main.transform.position);
    }
}
