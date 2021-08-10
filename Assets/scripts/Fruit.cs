using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private AudioSource soundCollected;
    public GameObject collected;
    public int Score;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        soundCollected = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag =="Player")
        {
            sr.enabled=false;
            circle.enabled=false;
            collected.SetActive(true);
            soundCollected.Play();

            GameController.instance.totalScore += Score; 
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.3f);
        }
        
    }
}