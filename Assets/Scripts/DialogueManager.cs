using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessage;
    Actor[] currentActor;
    int activeMessage;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors) 
    {
        currentMessage = messages;
        currentActor = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started");
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessage[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActor[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage<currentMessage.Length)
        {
            DisplayMessage();
        }
        else 
        {
            isActive = false;
            Debug.Log("Message ended!");
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessage();
            Debug.Log("Next");
        }
    }

}
