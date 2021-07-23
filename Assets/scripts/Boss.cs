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
    public Transform headPoint;
    public GameObject Fruit;

    private float timer;
    private Animator anim;
    private Rigidbody2D rig;
    


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {if(col.gameObject.tag == "Player")
    
            {
             float height =  col.contacts[0].point.y - headPoint.position.y; //checando se o player esta tocando a cabeca do inimigo
             if(height > 0 && !playerDestroyed) //se o valor for maior q 0,executa animação morrendo e destroi logo em seguida o inimigo
                {
                 col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse); //faz o player dar um pulinho 
                 
                 anim.SetTrigger("SpikeManDie"); //animação morrendo
                 Fruit.SetActive(true);
                 rig.bodyType = RigidbodyType2D.Kinematic;

                 Destroy(gameObject, 0.30f); //destroy para sumir
                 
                } else
                {
                 playerDestroyed = true;
                 GameController.instance.ShowGameOver();
                 Destroy(col.gameObject);
               }
            }
    }
}




