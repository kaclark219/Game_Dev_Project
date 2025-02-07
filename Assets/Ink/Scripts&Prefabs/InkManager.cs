using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Choice = Ink.Runtime.Choice;
using Story = Ink.Runtime.Story;

public class InkManager : MonoBehaviour
{
    [SerializeField] private NPCManager NPCManager;
    [SerializeField] private TextAsset LoadGlobalsJSON;
    [SerializeField] private TextAsset InkJsonAsset;
    [SerializeField] private Story Story;

    [SerializeField] private GameObject UI;
    [SerializeField] private TextMeshProUGUI TextBox;

    [SerializeField] private VerticalLayoutGroup ChoiceButtonContainer;

    [SerializeField] private Button ChoiceButtonPrefab;

    private DialogueVariables DialogueVariables;

    private Coroutine PrintCoroutine = null;
    private string text;

    private void Start()
    {
        DialogueVariables = new DialogueVariables(LoadGlobalsJSON);
        NPCManager = FindObjectOfType<NPCManager>();    
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
            TextBox.text = text;
            PrintCoroutine = null;
            return;
        }

        if (Story.canContinue)
        {
            text = Story.Continue();
            text = text?.Trim();
            TextBox.text = "";
            ApplyStyling();

            PrintCoroutine = StartCoroutine(PrintLine());
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
    IEnumerator PrintLine()
    {
        foreach (char c in text)
        {
            TextBox.text += c;
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

    public Ink.Runtime.Object GetVariableState(string name)
    {
        Ink.Runtime.Object variableValue = null;
        DialogueVariables.variables.TryGetValue(name, out variableValue);
        if (variableValue != null)
        {
            Debug.Log("Ink variable was found to be null: " + name);
        }
        return variableValue;
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

    Button CreateChoiceButton(string text)
    {
        Button button = Instantiate(ChoiceButtonPrefab);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
        button.transform.SetParent(ChoiceButtonContainer.transform, false); 
        return button;
    }
    #endregion

}
