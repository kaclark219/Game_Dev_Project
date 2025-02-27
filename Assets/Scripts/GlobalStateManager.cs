using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    [SerializeField] private DialogueVariables dialogueVariables;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DaySystem daySystem;

    private void Awake()
    {
        dialogueVariables = GameObject.Find("InkManager").GetComponent<DialogueVariables>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();  
        daySystem = GetComponent<DaySystem>();  
    }

    private void Start()
    {
        LoadAllData();
    }

    public void SaveAllData()
    {
        Debug.Log("Saving Data...");
        dialogueVariables.SaveData();
        playerData.SaveData();
        daySystem.SaveData();
    }

    public void LoadAllData()
    {
        Debug.Log("Loading Data...");
        dialogueVariables.LoadData();
        playerData.LoadData();
        daySystem.LoadData();
    }

    public void ResetAllData()
    {
        Debug.Log("Resetting Data Data...");
        dialogueVariables.ResetData();
        playerData.ResetData();
        daySystem.ResetData();
    }
    private void OnApplicationQuit()
    {
        SaveAllData();
    }
}
