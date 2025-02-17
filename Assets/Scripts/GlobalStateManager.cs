using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    [SerializeField] private DialogueVariables dialogueVariables;
    [SerializeField] private PlayerData playerData;

    private void Start()
    {
        LoadAllData();
    }

    public void SaveAllData()
    {
        dialogueVariables.SaveData();
        playerData.SaveData();
    }

    public void LoadAllData()
    {
        Debug.Log("Loading Data...");
        playerData.LoadData();
        dialogueVariables.LoadData();
    }

    public void ResetAllData()
    {
        dialogueVariables.ResetData();
        playerData.ResetData();
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Saving Data...");
        SaveAllData();
    }
}
