using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround: MonoBehaviour
{

    public static AudioSource audioSource;
    Vector2 posIniziale;
    // Start is called before the first frame update
    void Start()
    {
        posIniziale = transform.position;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            if (transform.position.x >= -4.4)
            {
                transform.position = new Vector2(transform.position.x - 6f * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = posIniziale;
            }
        }
    }
}
