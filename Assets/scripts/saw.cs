using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool direita = true;
    private float timer;
    private AudioSource soundSaw ;

    void Start()
    {
        soundSaw = GetComponent<AudioSource>();
    }

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
    }

}
