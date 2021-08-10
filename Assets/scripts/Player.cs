using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player : MonoBehaviour

{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private AudioSource soundJump;
    private Rigidbody2D rig;
    private Animator animacao;
    bool toFloat;

    void Start() // o que tiver aqui dentro sera chamado 1vez
    {
        rig = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        soundJump = GetComponent<AudioSource>();
    }

    void Update() //oq tiver aqui dentro é chamado a cada frame
    {
        Move(); //chamando metodos
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f ) //animação caminhando para direita
        {
            animacao.SetBool("walk", true); 
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f ) //animação caminhando para esquerda
        {
            animacao.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f); //sprite rotacionado 180° para esquerda
        }

        if(Input.GetAxis("Horizontal") == 0f )  // animação de quando estiver parado
        {
            animacao.SetBool("walk", false); 
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") & !toFloat) // input do unity
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                soundJump.Play();
                animacao.SetBool("jump", true);  //animação para pular
            
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    soundJump.Play();
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
             animacao.SetBool("jump", false);  // nao pular quando toca o chao 
            
        }
        if (collision.gameObject.tag == "trap")
        {
            GameController.instance.ShowGameOver(); //chamar tela game over quando tocar na armadilha
            Destroy(gameObject); 
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
            animacao.SetBool("jump", false);  //durante pulo , nao ficar com animação de correr junto
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 10)
        {
            toFloat = true; //enqnt estiver no ventilador player não pode pular
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 10)
        {
            toFloat = false; //saiu do ventilador ja pode pular novamente
        }
    }
}