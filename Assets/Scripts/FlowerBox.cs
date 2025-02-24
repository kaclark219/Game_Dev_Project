using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBox : InteractableObj
{
    private int CycleIndex = 0;
    string PlantedFlower = "";
    bool WateredToday = false;
    private Dictionary<string, int> daysToGrow = new Dictionary<string, int>();

    void Start()
    {
        base.Start();
        daysToGrow.Add("Daisy", 2);
    }

    public override void OnInteract()
    {
        if (true && PlantedFlower == "")
        {
           Plant();
        }
        else if (true && daysToGrow[PlantedFlower] == CycleIndex && !WateredToday)
        {
            StartCoroutine(Harvest());
        }
        else if (true && !WateredToday)
        { //Replace with (has enough energy)
            ;//Decrease energy
            StartCoroutine(Water());
        }
    }

    public void Plant()
    {
        //Open UI and select a plant
        //return "Daisy"; //Placeholder
        Debug.Log("Plant");
    }

    public IEnumerator Water()
    {
        //Water animation
        plint.pm.canmove = false;
        yield return new WaitForSeconds(1);
        plint.pm.canmove = true;
        CycleIndex++;
        WateredToday = true;
        Debug.Log("Watered");
    }

    public IEnumerator Harvest()
    {
        //Water animation
        plint.pm.canmove = false;
        yield return new WaitForSeconds(1);
        plint.pm.canmove = true;
        PlantedFlower = "";
        CycleIndex = 0;
        Debug.Log("Harvested");
    }
}
