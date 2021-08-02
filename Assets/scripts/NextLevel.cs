using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string lvlName;
    private AudioSource soundNextLevel;

    void Start()
    {  
        soundNextLevel = GetComponent<AudioSource>(); 
        
        
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player" & GameController.instance.totalScore >= 100 )
        {
            DontDestroyOnLoad(soundNextLevel);
            soundNextLevel.Play();
            Destroy(gameObject,0.10f);
            SceneManager.LoadScene(lvlName);

        }
    
    }

}