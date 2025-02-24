using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int day;
    public int week;

    private const string dayKey = "DAY";

    private PlayerData playerData;

    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }
    public void NextDay()
    {
        day++;
        week = (day % 3) + 1;
        LoadDay(day);
    }

    public int GetDay()
    {
        return day;
    }

    public int GetWeek()
    {
        return week;
    }

    public void LoadDay(int day)
    {
        // move NPCS
        // reset NPC daily interaction

        // update Flowerbox
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(dayKey, day);
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(dayKey))
        {
            day = PlayerPrefs.GetInt(dayKey);
        }
        else
        {
            day = 1;
        }

        week = (day % 3) + 1;

        LoadDay(day);
    }
    public void ResetData()
    {
        day = 1;
        week = 1;
        LoadDay(day);
    }
}
