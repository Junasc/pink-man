using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
   public Transform topPoint;

    void OnCollisionEnter2D(Collision2D col)
    {
        if( col.gameObject.tag == "Player")
        {
             float height =  col.contacts[0].point.y - topPoint.position.y; //se player tocar em cima do trofeu 
             if(height > 0 )
             {
                 GameController.instance.ShowGameOver(); // chama cena de finalização do jogo
                 Destroy(col.gameObject);
             }
        }
    }
}
