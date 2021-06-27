using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Trampoline : MonoBehaviour

{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
             anim.SetTrigger("jump");
        }
            
    }
}
