using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // GameOver
    public GameObject gameover;
    // Restart BTN
    public GameObject restart;
    // Prefab bullet
    //public GameObject bulletV;
    public GameObject bullet;
    // Point to shoot from
    public GameObject bulletPositionH;
    // Point to shoot from
    //public GameObject bulletPositionV;
    // Gravity
    Rigidbody2D rb;
    // Speed
    public float speed;
    // Movement Vertical
    public Vector2 PlayerDirection;
    public GameObject PauseBTN;

    AudioSource audioSource;





    public static bool IsGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the user clicks the left mouse button and the game is not in game over
        if (Input.GetMouseButtonDown(1) && !GameController.gameover)
        {
            if (IsGamePaused)
            {
                return;
            }
            else
            {
                audioSource.Play();
                // Instantiate the "shot" prefab and start it from the position where the bullet position is
                GameObject bulletFire = (GameObject)Instantiate(bullet);
                bulletFire.transform.position = bulletPositionH.transform.position;
            }
            
        }

        //if (Input.GetMouseButtonDown(1) && !GameController.gameover)
        //{
        //    audioSource.Play();
        //    // Instantiate the "shot" prefab and start it from the position where the bullet position is
        //    GameObject bulletFire = (GameObject)Instantiate(bulletV);
        //    bulletFire.transform.position = bulletPositionV.transform.position;
        //}

        // DirectionY
        if (!GameController.gameover)
        {
            float directionY = Input.GetAxisRaw("Vertical");
            // Specifies the direction of movement
            PlayerDirection = new Vector2(0, directionY).normalized;
        }
     
    }

    private void FixedUpdate()
    {
        // Makes the player move in the direction chosen earlier
        rb.velocity = new Vector2(0, PlayerDirection.y * speed);


        //if (Input.GetMouseButtonDown(1) && !GameController.gameover)
        //{
        //    audioSource.Play();
        //    // Instantiate the "shot" prefab and start it from the position where the bullet position is
        //    GameObject bulletFire = (GameObject)Instantiate(bullet);
        //    bulletFire.transform.position = bulletPositionH.transform.position * Time.deltaTime;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if it collides with a game object with the "Asteroid" tag
        if (collision.gameObject.tag == "Asteroid")
        {
            // Put the game in GameOver
            GameController.gameover = true;
            // Show GameOver
            gameover.SetActive(true);
            // Put the Restart button visible
            restart.SetActive(true);
            PauseBTN.SetActive(false);
        }
       
    }
}
