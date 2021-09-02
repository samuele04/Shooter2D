using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Speed
    float speed;
    // giaContato = false/no
    bool giaContato = false;

    public GameObject Asteroids;
    AudioSource audioSource;
    private void Start()
    {
        // set the speed to 8
        speed = 8f;
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
         
        Vector2 position = transform.position;

        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));

        if(transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            audioSource.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.7f);
            if (!giaContato)
            {
                giaContato = true;
                Punti.valorePuniti += 1;
            }
        }
    }
}
