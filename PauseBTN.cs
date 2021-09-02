using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBTN : MonoBehaviour
{
    public GameObject optionMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Pause()
    {
        Time.timeScale = 0;
        optionMenu.SetActive(true);
        Player.IsGamePaused = true;
        BackGround.audioSource.Pause();
    }

    public void Resume()
    {
        optionMenu.SetActive(false);
        Time.timeScale = 1f;
        Player.IsGamePaused = false;
        BackGround.audioSource.Play();
    }

    public void Menu()
    {
        GameController.gameover = false;
        SceneManager.LoadScene(0);
    }
}
