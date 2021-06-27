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
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    } 

    public void ShowGameOver ()
    {
        GameOver.SetActive(true);
    }

     public void RestartGame(string levelName)
    {
      SceneManager.LoadScene(levelName); // esse metodo vai reiniciar a cena 
    }

}


    
