using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour
{
    public Text dialogueText;

    void Start()
    {
        dialogueText.text = "";
    }

    public void DisplayDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }
}

