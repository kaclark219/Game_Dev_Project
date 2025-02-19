using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class NPCDialogueManager : MonoBehaviour
{
    private List<NPCPortrait> NPCs;
    [SerializeField] private GameObject NPCPrefab;
    public Transform leftLocation;
    public Transform centerLocation;
    public Transform rightLocation;
    [Space]
    [SerializeField] private NPCMoods PlayerMoods;
    [SerializeField] private NPCMoods GeraldMoods;
    [SerializeField] private NPCMoods SebastianMoods;
    [SerializeField] private NPCMoods CharlieMoods;
    [SerializeField] private NPCMoods MeganMoods;
    [SerializeField] private NPCMoods AvaMoods;
    [SerializeField] private NPCMoods BruceMoods;
    [SerializeField] private NPCMoods MaddieMoods;
    [SerializeField] private NPCMoods PoppyMoods;
    [SerializeField] private NPCMoods LindaMoods;
    [SerializeField] private NPCMoods JeremyMoods;

    private void Start()
    {
        NPCs = new List<NPCPortrait>();
    }

    public void ShowCharacter(NPCName name, NPCPosition position, NPCMood mood)
    {
        var character = NPCs.FirstOrDefault(x => x.Name == name);

        if (character == null)
        {
            GameObject characterObject;
            switch (position)
            {
                case NPCPosition.Left:
                    characterObject = Instantiate(NPCPrefab, leftLocation.transform, false);
                    break;
                case NPCPosition.Right:
                    characterObject = Instantiate(NPCPrefab, rightLocation.transform, false);
                    break;
                case NPCPosition.Center:
                    characterObject = Instantiate(NPCPrefab, centerLocation.transform, false);
                    break;
                default:
                    Debug.LogError("Invalid NPC Position");
                    return;
            }

            character = characterObject.GetComponent<NPCPortrait>();

            NPCs.Add(character);
        }
        else if (character.IsShowing)
        {
            Debug.LogWarning($"Failed to show character {name}. Character already showing");
            return;
        }
        character.Init(name, position, mood, GetMoodSetForCharacter(name));
    }

    public void ShowCharacter(string name, string position, string mood)
    {
        if (!Enum.TryParse(name, out NPCName nameEnum))
        {
            Debug.LogWarning($"Failed to parse character name to enum: {name}");
            return;
        }

        if (!Enum.TryParse(position, out NPCPosition positionEnum))
        {
            Debug.LogWarning($"Failed to parse character position to enum: {position}");
            return;
        }

        if (!Enum.TryParse(mood, out NPCMood moodEnum))
        {
            Debug.LogWarning($"Failed to parse character mood to enum: {mood}");
            return;
        }

        ShowCharacter(nameEnum, positionEnum, moodEnum);
    }

    public void HideCharacter(string name)
    {
        if (!Enum.TryParse(name, out NPCName nameEnum))
        {
            Debug.LogWarning($"Failed to parse character name to character enum: {name}");
            return;
        }

        HideCharacter(nameEnum);
    }

    public void HideCharacter(NPCName name)
    {
        var character = NPCs.FirstOrDefault(x => x.Name == name);
        if (character?.IsShowing != true)
        {
            Debug.LogWarning($"Character {name} is not currently shown. Can't hide it.");
            return;
        }
        else
        {
            character.Hide();
        }
    }

    public void ChangeMood(string name, string mood)
    {

        if (!Enum.TryParse(name, out NPCName nameEnum))
        {
            Debug.LogWarning($"Failed to parse character name to character enum: {name}");
            return;
        }

        if (!Enum.TryParse(mood, out NPCMood moodEnum))
        {
            Debug.LogWarning($"Failed to parse character mood to enum: {mood}");
            return;
        }

        ChangeMood(nameEnum, moodEnum);
    }

    public void ChangeMood(NPCName name, NPCMood mood)
    {
        var character = NPCs.FirstOrDefault(x => x.Name == name);

        if (character?.IsShowing != true)
        {
            Debug.LogWarning($"Character {name} is not currently shown. Can't change the mood.");
            return;
        }
        else
        {
            character.ChangeMood(mood);
        }
    }

    private NPCMoods GetMoodSetForCharacter(NPCName name)
    {
        switch (name)
        {
            case NPCName.Player:
                return PlayerMoods;
            case NPCName.Gerald:
                return GeraldMoods;
            case NPCName.Sebastian:
                return SebastianMoods;
            case NPCName.Charlie:
                return CharlieMoods;
            case NPCName.Megan:
                return MeganMoods;
            case NPCName.Ava:
                return AvaMoods;
            case NPCName.Bruce:
                return BruceMoods;
            case NPCName.Maddie:
                return MaddieMoods;
            case NPCName.Poppy:
                return PoppyMoods;
            case NPCName.Linda:
                return LindaMoods;
            case NPCName.Jeremy:
                return JeremyMoods;
            default:
                Debug.LogError($"Could not find moodset for {name}");
                return null;
        }
    }
}
