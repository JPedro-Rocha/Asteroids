using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    private int score;

    private int asteroidsRemaining;
    private int wave = 1;
    private int increaseEachWave = 4;
    public GameObject nave;
    public GameObject firePoint;

    public Text scoreText;
    public Text waveText;




    // Start is called before the first frame update
    void Start()
    {
        ComecarJogo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ComecarJogo();
        }
    }

    void ComecarJogo()
    {
        scoreText.text = "SCORE:" + score;
        waveText.text = "WAVE: " + wave;

        score = 0;
        wave = 1;
        gerarAsteroides();
        Instantiate(nave, new Vector3(0, 0, 0), transform.rotation);
        //Instantiate(firePoint);
        firePoint = Instantiate(firePoint, new Vector3(0, 0, 0), transform.rotation);
        //firePoint.transform.parent = nave.transform;
    }

    void gerarAsteroides()
    {

        destruirAsteroides();
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {
            bool asteroidegerado = false;
            while (!asteroidegerado)
            {
                // Spawn an asteroid
                Vector3 asteroidPosition = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-6.0f, 6.0f), 0);
                if ((asteroidPosition - nave.transform.position).magnitude < 4)
                {
                    continue;
                    /*esse if vai checar se a posição do asteroide que vai ser spawnado
                      é diferente da posição da nave, para não spawnar em cima da nave*/
                }
                else
                {
                    Instantiate(asteroid, asteroidPosition, Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
                    asteroidegerado = true;
                }

            }
        }
        waveText.text = "WAVE: " + wave;

    }

    void destruirAsteroides()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("AsteroideGrande");
        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 = GameObject.FindGameObjectsWithTag("AsteroidePequeno");
        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }

    public void aumentarScore()
    {
        scoreText.text = "SCORE:" + score;
        score++;


        if (asteroidsRemaining < 1)
        {
            wave++;
            gerarAsteroides();
        }
    }

    public void diminuirAsteroides()
    {
        asteroidsRemaining--;
    }

    public void dividirAsteroide()//adicionar 1 ao número de asteroides quando dois pequenos aparecem
    {
        asteroidsRemaining += 1;
    }
}
