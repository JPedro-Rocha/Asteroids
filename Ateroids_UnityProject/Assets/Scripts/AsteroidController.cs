using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public AudioClip destroy;
    public GameObject smallAsteroid;

    private GameController gameController;

    void Start()
    {
        //Referencia o gameObejct do controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();

        // aplica força em um asteroide 
        GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(-50.0f, 150.0f));

        //aplica rotação e velocidade
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-0.0f, 90.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag.Equals("Finish"))
        {

            // Destroy the bullet
            Destroy(c.gameObject);

            // If large asteroid spawn new ones
            if (tag.Equals("asteroide grande"))
            {
                // Spawn small asteroids
                Instantiate(smallAsteroid,
                    new Vector3(transform.position.x - .5f,
                        transform.position.y - .5f, 0),
                        Quaternion.Euler(0, 0, 90));

                // Spawn small asteroids
                Instantiate(smallAsteroid,
                    new Vector3(transform.position.x + .5f,
                        transform.position.y + .0f, 0),
                        Quaternion.Euler(0, 0, 0));

                // Spawn small asteroids
                Instantiate(smallAsteroid,
                    new Vector3(transform.position.x + .5f,
                        transform.position.y - .5f, 0),
                        Quaternion.Euler(0, 0, 270));

                gameController.SplitAsteroid(); // +2

            }
            else
            {
                // Just a small asteroid destroyed
                gameController.DecrementAsteroids();
            }

            // Play a sound
            AudioSource.PlayClipAtPoint(
                destroy, Camera.main.transform.position);

            // Add to the score
            gameController.IncrementScore();

            // Destroy the current asteroid
            Destroy(gameObject);

        }

    }*/

    void OnTriggerEnter2D(Collider2D bullet)//asteroide destruído
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(destroy, Camera.main.transform.position);
    }
}
