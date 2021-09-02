using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{



    float spawnTimer;
    float spawnRate = 3f;
    public GameObject asteroide;
    public static bool gameover;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!gameover)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                spawnTimer -= spawnRate;
                Vector2 spawnPos = new Vector2(10f, Random.Range(4f, -4f));
                Instantiate(asteroide, spawnPos, Quaternion.identity);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name == "asteroid-small")
    //    {
    //        audioSource.Play();
    //        Destroy(gameObject);
            
    //    }
    //}
}
