using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

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


    void Start()
    {
        instance = this;
        soundMusic = GetComponent<AudioSource>();
        soundGameOver = GetComponent<AudioSource>();
        Time.timeScale = 1f;

    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
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

    // public void ShowMenuEsc()
    // {
    //      MenuEsc.SetActive(true); 
           
    // }
   

    public void RestartGame(string levelName)
    {
      SceneManager.LoadScene(levelName); // esse metodo vai reiniciar a cena 
     
    }

    public void Exit()
    {
        Application.Quit();
    }
}


    
