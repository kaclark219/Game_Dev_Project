using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private enum TimeOfDay { Morning, Afternoon, Evening }
    private const string nameKey = "PLAYER_NAME";
    private const string moneyKey = "MONEY";
    private const int startEnergy = 50;
    private const int startMoney = 0;

    [SerializeField] private DayNightCycle dayNightCycle;

    private string playerName = "";
    private int money;
    private int energy;

    private TimeOfDay timeOfDay = TimeOfDay.Morning;
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
    public void ResetEnergy()
    {
        energy = startEnergy;
        timeOfDay = TimeOfDay.Morning;
        // NPC morning position
    }
    public void ModifyEnergy(int amount)
    {
        energy += amount;
        dayNightCycle.UpdateLight(energy);
        if (energy <= 36 && energy > 15 && timeOfDay != TimeOfDay.Afternoon)
        {
            timeOfDay = TimeOfDay.Afternoon;
            // Trigger NPC position change
        }
        else if (energy <= 15 && energy > 0 && timeOfDay != TimeOfDay.Evening)
        {
            timeOfDay = TimeOfDay.Evening;
            // Trigger NPC position change
        }
        if (energy <= 0)    // change to Next Day
        {
            GameObject.Find("GameManager").GetComponent<DaySystem>().NextDay();
            ResetEnergy();
        }
    }

    public string GetName()
    {
        return playerName;
    }
    public void SetName(string name)
    {
        playerName = name;
        GameObject.Find("InkManager").GetComponent<DialogueVariables>().ChangeVariable("PlayerName", playerName);
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
            SetName(PlayerPrefs.GetString(nameKey));
        }
        else
        {
            SetName("Y/N");
        }

        if (PlayerPrefs.HasKey(moneyKey))
        {
            money = PlayerPrefs.GetInt(moneyKey);
        }
        else
        {
            money = startMoney;
        }
    }

    public void ResetData()
    {
        SetName("Y/N");
        money = startMoney;
        ResetEnergy();
    }

}
