using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour 
{
    private Rigidbody2D rig;
    private Animator anim; //pq teremos que manipular a animação dele correndo , morrendo 

    public float speed; //velocidade de movimentação do inimmigo

    public Transform rightColisor; // os objetos q fica direita do inimigo
    public Transform leftColisor; //objeto a esquerda do inimigo
    public Transform headPoint; //ponto em cima da cabeça do inimigo, p saber qnd player tocou 

    private bool colliding; //serve para detectar qnd inimigo tocou na parede  ou n

    void Start()
    { 
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y); //movimentando o inimigo
        colliding = Physics2D.Linecast(rightColisor.position , leftColisor.position);

        /* Physic2D.linecast -> desenha um colisor invisivel em formato de linha em 2 posições na cena
        as posições que estao dentro do parametro.
        */
        if(colliding)
        {

        }


    }
}