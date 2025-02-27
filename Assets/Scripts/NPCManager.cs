using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] string stage = "1";
    string currentstage;
    [SerializeField] GameObject[] NPCs;
    string day = "1";
    Dictionary<string, Vector2> coords = new Dictionary<string, Vector2>();

    void Start(){
        string[] lines = Resources.Load<TextAsset>("NPClocations").ToString().Split("\n");
        for(int i = 1; i < lines.Length; i++){
            string[] info = lines[i].Split(",");
            coords.Add(info[0], new Vector2(int.Parse(info[1]), int.Parse(info[2]))); //If this line errors make sure the CSV doesn't have a blak line at the end
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stage != currentstage){
            foreach(GameObject npc in NPCs){
                npc.transform.position = coords[npc.name + day + stage];
            }
            currentstage = stage;
        }
    }
}
