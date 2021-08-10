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


    void Start()
    {
        instance = this;
        soundMusic = GetComponent<AudioSource>();
        soundGameOver = GetComponent<AudioSource>();

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

    public void RestartGame(string levelName){
      SceneManager.LoadScene(levelName); // esse metodo vai reiniciar a cena 
     
    }

    public void Exit()
    {
        Application.Quit();
    }
}


    
