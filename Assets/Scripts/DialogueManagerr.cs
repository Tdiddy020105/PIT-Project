using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DialogueManagerr : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject Background;
    [SerializeField] private Image characterPortraitImage;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private TextMeshProUGUI notificationText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerr instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManagerr GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        Background.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        // Check if a question is being displayed
        if (currentStory.currentChoices.Count > 0)
        {
            // Disable the ability to continue with "R" key
            return;
        }

        // Execute the method when "R" key is pressed to continue the story
        if (Input.GetKeyDown(KeyCode.R))
        {
            ContinueStory();
        }
    }

    // This method enters the dialogue mode by initializing the current story with Ink JSON data and activating the UI elements
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Background.SetActive(true);

        ContinueStory();
    }

    // This method exits the dialogue mode by deactivating the UI elements and setting dialogueIsPlaying to false
    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        Background.SetActive(false);
        dialogueText.text = "";

        if (!notificationPanel.activeSelf) // Check if the notification panel is not already active
        {
            StartCoroutine(ShowNotificationCoroutine());
        }
    }

    // This coroutine shows a notification panel with a text message for a certain duration before hiding it
    private IEnumerator ShowNotificationCoroutine()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the duration of the delay as needed

        // Show the notification panel by setting it to true and display a text message
        notificationPanel.SetActive(true);
        notificationText.text = "Goed gedaan!";

        yield return new WaitForSeconds(2f); // Adjust the duration of the delay as needed

        // Hide the notification panel by setting it to false
        notificationPanel.SetActive(false);
        ExitDialogueMode();
    }

    // This method continues the story, displaying the next line of dialogue or handling the end of the story
    private void ContinueStory()
    {
        // Check if the story can continue
        if (currentStory.canContinue)
        {
            string storyText = currentStory.Continue();
            // Replace line breaks with paragraph tags or rich text formatting
            storyText = storyText.Replace("\n", "<br>"); // Example: Replace "\n" with HTML "<br>" tag

            dialogueText.text = storyText;
            DisplayChoices(); // Execute the method to display choices if any
        }
        else
        {
            StartCoroutine(ShowNotificationCoroutine()); // Start the coroutine for showing notifications
        }
    }

    // This method displays the choices for the player to select
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // Check if the number of choices exceeds the capacity of the UI
        if (currentChoices.Count > choices.Length)
        {
            // Output an error message indicating that more choices were given than the UI can support
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // Iterate through each 'Choice' object in the 'currentChoices' collection
        foreach (Choice choice in currentChoices)
        {
            // Activate the game object associated with the current choice
            choices[index].gameObject.SetActive(true);
            // Set the text of the choice's corresponding text UI element
            choicesText[index].text = choice.text;
            // Increment the index to move to the next choice and text UI element
            index++;
        }

        // Deactivate any remaining choice game objects
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        // Check if there are any special tags in the current story
        if (currentStory.currentTags.Count > 0)
        {
            foreach (string tag in currentStory.currentTags)
            {
                if (tag.StartsWith("speaker:"))
                {
                    string speakerName = tag.Substring(tag.IndexOf(":") + 1);
                    speakerNameText.text = speakerName;
                    break;
                }

                if (tag.StartsWith("portrait:"))
                {
                    string characterPortrait = tag.Substring(tag.IndexOf(":") + 1);
                    string spritePath = "NPC1Dialogue"; // Path without the file extension
                    Sprite portraitSprite = Resources.Load<Sprite>("NPC1Dialogue");
                    if (portraitSprite != null)
                    {
                        characterPortraitImage.sprite = portraitSprite;
                    }
                    else
                    {
                        Debug.LogError("Failed to load sprite: " + spritePath);
                    }
                    break;
                }
            }
        }
        else
        {
            speakerNameText.text = string.Empty;
        }

        StartCoroutine(SelectFirstChoice());
    }

    // This coroutine selects the first choice automatically after a frame delay
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    // This method is called when the player selects a choice
    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex >= 0 && choiceIndex < currentStory.currentChoices.Count)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        else
        {
            Debug.LogError("Invalid choice index: " + choiceIndex);
        }
    }

    private IEnumerator LoadSprite(string path)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(path))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to load sprite: " + www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                characterPortraitImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
        }
    }
}
