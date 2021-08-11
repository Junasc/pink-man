using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public Transform topPoint;

    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // float height =  col.contacts[0].point.y - topPoint.position.y; //se player tocar em cima do trofeu 
            // if (height > 0)
            // {
                Player.instance.animacao.SetBool("win", true);
                Destroy(Player.instance.gameObject, 0.4f);
                yield return new WaitForSeconds(0.8f);
                GameController.instance.ShowGameOver(); // chama cena de finalização do jogo
            // }
        }
    }
}
