using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Choice = Ink.Runtime.Choice;
using Story = Ink.Runtime.Story;

public class InkManager : MonoBehaviour
{
    [SerializeField] private NPCDialogueManager NPCManager;
    [SerializeField] private TextAsset InkJsonAsset;
    [SerializeField] private Story Story;

    [SerializeField] private GameObject UI;
    [SerializeField] private TextMeshProUGUI TextBox;

    [SerializeField] private VerticalLayoutGroup ChoiceButtonContainer;

    [SerializeField] private Button ChoiceButtonPrefab;

    [SerializeField] private DialogueVariables DialogueVariables;

    private Coroutine PrintCoroutine = null;
    private string text;

    private void Start()
    {
        if (DialogueVariables == null)
        {
            GetComponent<DialogueVariables>();
        }
        NPCManager = FindObjectOfType<NPCDialogueManager>();    
        StartStory();
    }

    public void StartDialogue(TextAsset textAsset)
    {
        Debug.Log("Starting Dialogue");
        InkJsonAsset = textAsset;
        StartStory();
        UI.SetActive(true);
    }

    private void StartStory()
    {
        Story = new Story(InkJsonAsset.text);
        // Connects function calls in Ink file with function calls in Unity
        Story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => NPCManager.ShowCharacter(name, position, mood));
        Story.BindExternalFunction("HideCharacter", (string name) => NPCManager.HideCharacter(name));
        Story.BindExternalFunction("ChangeMood", (string name, string mood) => NPCManager.ChangeMood(name, mood));
        DialogueVariables.StartListening(Story);
        DisplayNextLine();
    }

    public void StartStory(TextAsset newStory)
    {
        InkJsonAsset = newStory;
        Story = new Story(InkJsonAsset.text);
        // Connects function calls in Ink file with function calls in Unity
        Story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => NPCManager.ShowCharacter(name, position, mood));
        Story.BindExternalFunction("HideCharacter", (string name) => NPCManager.HideCharacter(name));
        Story.BindExternalFunction("ChangeMood", (string name, string mood) => NPCManager.ChangeMood(name, mood));
        DialogueVariables.StartListening(Story);
        DisplayNextLine();
    }

    private void EndStory()
    {
        Debug.Log("Exiting Dialogue");
        Story.ResetState();
        DialogueVariables.StopListening(Story);
        UI.SetActive(false);
    }

    public void DisplayNextLine()
    {
        // Check if a line is being printed
        if (PrintCoroutine != null)
        {
            StopCoroutine(PrintCoroutine);
            TextBox.maxVisibleCharacters = text.Length;
            PrintCoroutine = null;
            return;
        }

        if (Story.canContinue)
        {
            text = Story.Continue();
            text = text?.Trim();
            if (text == "")
            {
                DisplayNextLine();
            }
            else
            {
                ApplyStyling();

                PrintCoroutine = StartCoroutine(PrintLine());
            }
        }
        else if (Story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else if (!Story.canContinue)
        {
            EndStory();
        }

    }

    // Coroutine to slowly print each character in a line.
    private IEnumerator PrintLine()
    {
        TextBox.text = text;
        TextBox.maxVisibleCharacters = 0;
        foreach (char c in text)
        {
            TextBox.maxVisibleCharacters++;
            yield return new WaitForSeconds(0.05f);
        }
        PrintCoroutine = null;
    }


    private void ApplyStyling()
    {
        if (Story.currentTags.Contains("thought")) {
            TextBox.fontStyle = FontStyles.Italic;
        }
        else
        {
            TextBox.fontStyle= FontStyles.Normal;
        }
    }

    #region CHOICES_FUNCTIONS
    // Displays all choices for a dialogue 
    private void DisplayChoices()
    {
        if (ChoiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) { return; }

        foreach (Choice choice in Story.currentChoices)
        {
            Button button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => OnClickChoiceButton(choice)); 
        }
    }

    
    private void OnClickChoiceButton(Choice choice)
    {
        Story.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
    }

    // Removes all choices
    private void RefreshChoiceView()
    {
        if (ChoiceButtonContainer != null)
        {
            foreach (Button button in ChoiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    private Button CreateChoiceButton(string text)
    {
        Button button = Instantiate(ChoiceButtonPrefab);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
        button.transform.SetParent(ChoiceButtonContainer.transform, false); 
        return button;
    }
    #endregion

}
