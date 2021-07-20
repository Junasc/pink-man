using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;
    private DialogueControl dc;
    bool onRadious; //para checar qnd o personagem tiver dentro do raio
    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>(); //findObjectType qnd jogo inicia procura objetos qSpeech tenham dialogueControl Anexado
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if (hit != null)
        {
            dc.Speech(profile, speechTxt, actorName);
        }
        else
        {
            dc.Destroy();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious); //desenha esfera de colisao 
    }
}
