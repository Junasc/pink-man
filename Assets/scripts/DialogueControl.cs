using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    //[Header("components")]
    public GameObject dialogueObj; //dialogueobj é a janela do dialogo

    public Image profile;
    public Text speechText;
    public Text actorNameText;

   // [Header("Settings")]
      
    public void Speech(Sprite p, string txt, string actorName) //metodo q o npc vai chamar para chamar o dialogo
    {
        dialogueObj.SetActive(true); //ativar o dialogo
        profile.sprite = p;
        speechText.text =  txt;
        actorNameText.text = actorName; //aqui esta se extraindo as info do npc
    }       

    public void Destroy() //metodo q o npc vai chamar para chamar o dialogo
    {
        dialogueObj.SetActive(false); //desativar o dialogo
    }    
    
}
