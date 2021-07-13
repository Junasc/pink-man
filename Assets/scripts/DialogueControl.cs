using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("components")]
    public GameObject dialogueObj; //dialogueobj é a janela do dialogo

    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed; //velocidade que o texto vai aparecer

    public void Speech(Sprite p, string txt, string actorName) //metodo q o npc vai chamar para chamar o dialogo
    {
        dialogueObj.SetActive(true); //ativar o dialogo
        profile.sprite = p;
        speechText.text = txt;
        actorNameText.text = actorName; //aqui esta se extraindo as info do npc
    }


}
