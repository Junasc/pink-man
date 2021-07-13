using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMan : MonoBehaviour 
{
    private Rigidbody2D rig;
    private Animator anim; //pq teremos que manipular a animação dele correndo , morrendo 

    public float speed; //velocidade de movimentação do inimmigo

    public Transform rightColisor; // os objetos q fica direita do inimigo
    public Transform leftColisor; //objeto a esquerda do inimigo
    public Transform headPoint; //ponto em cima da cabeça do inimigo, p saber qnd player tocou 
    public LayerMask layer; //com esse layer , pode selecionar qual tipo de layer o personagem pode bater

    private bool colliding; //serve para detectar qnd inimigo tocou na parede  ou n

    void Start()
    { 
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y); //movimentando o inimigo
        colliding = Physics2D.Linecast(rightColisor.position , leftColisor.position, layer);   

        /* Physic2D.linecast -> desenha um colisor invisivel em formato de linha em 2 posições na cena
        as posições que estao dentro do parametro.
        */
        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y); //invertendo a rotação 
            // ele começa em positivo , bate em algo , multiplica por -1 fica negativo, bate de novo , fica positivo e sucessivamente
            speed *= -1f; // faz o inimigo virar pra direção contraria 
            //se for negativo é esquerda , se for positivo direita 

        }
    }

        bool playerDestroyed;
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Player")
    
            {
             float height =  col.contacts[0].point.y - headPoint.position.y; //checando se o player esta tocando a cabeca do inimigo
             if(height > 0 && !playerDestroyed) //se o valor for maior q 0,executa animação morrendo e destroi logo em seguida o inimigo
                {
                 col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse); //faz o player dar um pulinho 
                 speed = 0;
                 anim.SetTrigger("blueDie"); //animação morrendo
                 //boxCollider2D.enabled = false;
                 //circleCollider2D.enabled = false;
                 rig.bodyType = RigidbodyType2D.Kinematic;

                 Destroy(gameObject, 0.25f); //destroy para sumir
                } else
                {
                 playerDestroyed = true;
                 GameController.instance.ShowGameOver();
                 Destroy(col.gameObject);
                }
                
            }
       }

}
