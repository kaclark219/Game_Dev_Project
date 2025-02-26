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
    [SerializeField] private NPCDialogueManager NPCDialogueManager;
    [SerializeField] private TextAsset InkJsonAsset;
    [SerializeField] private Story Story;

    [SerializeField] private GameObject UI;
    [SerializeField] private TextMeshProUGUI TextBox;

    [SerializeField] private VerticalLayoutGroup ChoiceButtonContainer;

    [SerializeField] private GameObject ChoiceButtonPrefab;

    [SerializeField] private DialogueVariables DialogueVariables;

    private NPC currentNPC;
    private Coroutine PrintCoroutine = null;
    private string text;

    private void Start()
    {
        if (DialogueVariables == null)
        {
            GetComponent<DialogueVariables>();
        }
        NPCDialogueManager = FindObjectOfType<NPCDialogueManager>();
        UI.SetActive(false);
    }
    private void StartStory()
    {
        Debug.Log("Starting Dialogue");
        Story = new Story(InkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        Story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => NPCDialogueManager.ShowCharacter(name, position, mood));
        Story.BindExternalFunction("HideCharacter", (string name) => NPCDialogueManager.HideCharacter(name));
        Story.BindExternalFunction("ChangeMood", (string name, string mood) => NPCDialogueManager.ChangeMood(name, mood));
        DialogueVariables.StartListening(Story);
        DisplayNextLine();
    }

    public void StartStory(TextAsset newStory, NPC npc)
    {
        Debug.Log("Starting Dialogue");

        currentNPC = npc; 
        InkJsonAsset = newStory;
        Story = new Story(InkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        Story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => NPCDialogueManager.ShowCharacter(name, position, mood));
        Story.BindExternalFunction("HideCharacter", (string name) => NPCDialogueManager.HideCharacter(name));
        Story.BindExternalFunction("ChangeMood", (string name, string mood) => NPCDialogueManager.ChangeMood(name, mood));
        DialogueVariables.StartListening(Story);
        DisplayNextLine();
    }

    private void EndStory()
    {
        Debug.Log("Exiting Dialogue");

        // Reset Dialogue 
        Story.ResetState();
        DialogueVariables.StopListening(Story);
        UI.SetActive(false);

        // Clear all Portraits
        NPCDialogueManager.ClearCharacters();

        // End Interaction for Player
        currentNPC.EndInteract();
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
            GameObject button = CreateChoiceButton(choice.text);

            button.GetComponentsInChildren<Button>()[0].onClick.AddListener(() => OnClickChoiceButton(choice)); 
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
            foreach (Transform button in ChoiceButtonContainer.transform)
            {
                Destroy(button.gameObject);
            }
        }
    }

    private GameObject CreateChoiceButton(string text)
    {
        GameObject buttonObj = Instantiate(ChoiceButtonPrefab);
        buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = text;
        buttonObj.transform.SetParent(ChoiceButtonContainer.transform, false);
        return buttonObj; ;
    }
    #endregion

}
