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

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }
    
    private static DialogueManagerr instance;

    private void Awake()
    {
        if(instance != null)
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
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        // Check if a question is being displayed
        if (currentStory.currentChoices.Count > 0)
        {
            // Disable the ability to continue with "R" key
            return;
        }

        // Continue with the story when "R" key is pressed
        if(Input.GetKeyDown(KeyCode.R))
        {
            ContinueStory();
        }
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Background.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        Background.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            string storyText = currentStory.Continue();
            // Replace line breaks with paragraph tags or rich text formatting
            storyText = storyText.Replace("\n", "<br>"); // Example: Replace "\n" with HTML "<br>" tag

            dialogueText.text = storyText;
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }



    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given" + currentChoices.Count);
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        if(currentStory.currentTags.Count > 0)
        {
            foreach(string tag in currentStory.currentTags)
            {
                if(tag.StartsWith("speaker:"))
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

    private IEnumerator SelectFirstChoice() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if(choiceIndex >= 0 && choiceIndex < currentStory.currentChoices.Count)
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


