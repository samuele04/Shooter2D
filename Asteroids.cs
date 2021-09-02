using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    bool giaContato = false;

     AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            transform.position = new Vector2(transform.position.x - 6f * Time.deltaTime, transform.position.y);

        }
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

       

        //if(!giaContato && transform.position.x < -8)
        //{
        //    giaContato = true;
        //    Punti.valorePuniti += 1;
        //}
    }

  
}

