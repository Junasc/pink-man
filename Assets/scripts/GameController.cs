using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;   

public class GameController : MonoBehaviour
{
    public int totalScore;
    public  Text scoreText;
    public GameObject GameOver;
    public static GameController instance;
    
    //private AudioSource soundGameOver;

    void Start()
    {
        instance = this;
       // soundGameOver = GetComponent<AudioSource>();
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    } 

    public void ShowGameOver()
    {
        //soundGameOver.Play();
        GameOver.SetActive(true);
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


    
