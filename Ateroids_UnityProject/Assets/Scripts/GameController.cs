using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    public GameObject asteroid;

    private int asteroidsRemaining;
    private int wave = 1;
    private int increaseEachWave = 4; 


    // Start is called before the first frame update
    void Start()
    {
        gerarAsteroides();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    void gerarAsteroides()
    {


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

}
