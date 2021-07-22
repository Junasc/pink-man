using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float radious;
    public float speed;
    public float moveTime;
    public bool direita = true;
    public bool cima = true;
    private float timer;


    void Update()
    {
        if(direita)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
        timer += Time.deltaTime;
        if(timer>= moveTime)
        {
            direita = !direita;
            timer = 0f;
        }

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
            timer = 3f;
        }
    }
}




