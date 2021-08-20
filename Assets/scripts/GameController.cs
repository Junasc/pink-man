using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Linq;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public  Text scoreText;
    public GameObject GameOver;
    public static GameController instance;
    public AudioSource soundMusic;
    public AudioSource soundGameOver;
    public GameObject MenuEsc; 
    private bool isPaused;
    private string[] scenesWithoutMenu = { "MainMenu", "credits", "HowToPlay" };


    void Start()
    {
        instance = this;
        soundMusic = GetComponent<AudioSource>();
        soundGameOver = GetComponent<AudioSource>();
        Time.timeScale = 1f;

    }

    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        if (Input.GetButtonDown("Cancel") && !scenesWithoutMenu.Contains(scene.name))
        {
            PauseScreen();
        }
    }

    public void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;

            MenuEsc.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            MenuEsc.SetActive(true);
        }

    }
   
    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    } 

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
        soundGameOver.Play();
    }

    public void RestartGame(string levelName)
    {
      SceneManager.LoadScene(levelName); // esse metodo vai reiniciar a cena 
     
    }

    public void Exit()
    {
        Application.Quit();
    }
}


    
