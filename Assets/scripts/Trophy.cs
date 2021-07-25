using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{

    
    void OnColiisionEnter2D(collision2D col )
    {
        if(GameObject.tag == "Player")
        {
            // quando o player tocar na parte de cima do trofeu chamar tela de finalização do jogo
        }
    }
}
