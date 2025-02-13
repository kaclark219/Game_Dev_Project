using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private string playerName = "";
    private int money = 0;
    private int energy = 100;

    private const string nameKey = "PLAYER_NAME";
    private const string moneyKey = "MONEY";
    private const string energyKey = "Energy";

    void Start()
    {
        LoadData();
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
        PlayerPrefs.SetInt(energyKey, energy);
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

        if(PlayerPrefs.HasKey(energyKey))
        {
            energy = PlayerPrefs.GetInt(energyKey);
        }
        else
        {
            energy = 0;
        }
    }

    public void ResetData()
    {
        playerName = "";
        money = 0;
        energy = 100;
    }

}
