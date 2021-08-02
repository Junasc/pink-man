using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool cima = true;
    private float timer;
    
    void Update()
    {
        
        if(cima) 
        {
           transform.Translate(Vector2.up * speed * Time.deltaTime);
        
        }
        else 
        {
          transform.Translate(Vector2.down * speed * Time.deltaTime);
          
        }
        timer += Time.deltaTime;

        if(timer>= moveTime)
        {
            cima = !cima;
            timer = 0f;
        }

    }

 }