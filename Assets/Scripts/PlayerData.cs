using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int Money;
    private int Energy;
    private int Suspicion;

    void Start()
    {
        Money = 100;
        Energy = 100;
        Suspicion = 0;
    }

    public int GetMoney()
    {
        return Money;
    }
    public void ModifyMoney(int amount)
    {
        Money += amount;
    }
    
    public int GetEnergy()
    {
        return Energy;
    }
    public void ModifyEnergy(int amount)
    {
        Energy += amount;
    }

    public int GetSuspicion() 
    { 
        return Suspicion; 
    }
    public void ModifySuspicion(int amount) 
    { 
        Suspicion += amount; 
    }

}
