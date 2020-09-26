using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    private int score;
    private int hiscore;
    private int asteroidsRemaining;
    private int wave = 1;
    private int increaseEachWave = 4;


    // Start is called before the first frame update
    void Start()
    {
        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        ComecarJogo();
    }

    // Update is called once per frame
    void Update()
    {
        //pegar todos os asteroids por tag, se o número for igual a zero spawn 
    }

    void ComecarJogo()
    {
        score = 0;
        wave = 1;
        gerarAsteroides();
    }

    void gerarAsteroides()
    {

        destruirAsteroides();
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {

            // Spawn an asteroid
            Instantiate(asteroid,
                new Vector3(Random.Range(-9.0f, 9.0f),
                    Random.Range(-6.0f, 6.0f), 0),
                    Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }

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
        score++;
        //if (score > hischore) hiscore = score;
        //PlayerPrefs.SetInt("hiscore", hiscore);

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
