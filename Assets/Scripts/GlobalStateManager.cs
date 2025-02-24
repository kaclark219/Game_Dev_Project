using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    [SerializeField] private DialogueVariables dialogueVariables;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DaySystem daySystem;

    private void Start()
    {
        LoadAllData();
    }

    public void SaveAllData()
    {
        dialogueVariables.SaveData();
        playerData.SaveData();
        daySystem.SaveData();
    }

    public void LoadAllData()
    {
        Debug.Log("Loading Data...");
        playerData.LoadData();
        dialogueVariables.LoadData();
        daySystem.LoadData();
    }

    public void ResetAllData()
    {
        dialogueVariables.ResetData();
        playerData.ResetData();
        daySystem.ResetData();
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Saving Data...");
        SaveAllData();
    }
}
