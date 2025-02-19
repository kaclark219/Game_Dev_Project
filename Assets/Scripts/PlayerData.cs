using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private DayNightCycle dayNightCycle;

    private string playerName = "";
    private int money = 0;
    private int energy = 100;

    private const string nameKey = "PLAYER_NAME";
    private const string moneyKey = "MONEY";

    void Start()
    {
        LoadData();
        ModifyEnergy(100);
    }

    public int GetMoney()
    {
        return money;
    }
    public void ModifyMoney(int amount)
    {
        money += amount;
    }
    
    public int GetEnergy()
    {
        return energy;
    }
    public void ModifyEnergy(int amount)
    {
        energy += amount;
        dayNightCycle.UpdateLight(energy);
    }

    public string GetName()
    {
        return playerName;
    }
    public void SetName(string name)
    {
        playerName = name;
    }   

    public void SaveData()
    {
        PlayerPrefs.SetString(nameKey, playerName); 
        PlayerPrefs.SetInt(moneyKey, money);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(nameKey))
        {
            playerName = PlayerPrefs.GetString(nameKey);
        }
        else
        {
            playerName = "";
        }

        if (PlayerPrefs.HasKey(moneyKey))
        {
            money = PlayerPrefs.GetInt(moneyKey);
        }
        else
        {
            money = 0;
        }
    }

    public void ResetData()
    {
        playerName = "";
        money = 0;
        energy = 100;
    }

}
