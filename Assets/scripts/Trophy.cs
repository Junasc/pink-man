using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
   public Transform topPoint;

    bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if( col.gameObject.tag == "Player")
        {
             float height =  col.contacts[0].point.y - topPoint.position.y;
             if(height > 0 )
             {
                 GameController.instance.ShowGameWin();
                 playerDestroyed =  true; 
                 Destroy(col.gameObject);
             }
        }
    }
}
