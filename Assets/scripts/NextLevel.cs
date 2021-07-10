using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string lvlName;
    void OnCollisionEnter2D(Collision2D collision)
{
        if (collision.gameObject.tag == "Player" & GameController.instance.totalScore >= 100 )
        {
            SceneManager.LoadScene(lvlName);
        }
    }

}