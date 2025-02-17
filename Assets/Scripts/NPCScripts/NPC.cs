using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{
    [SerializeField] NPCName name;
    NPCPosition dir = NPCPosition.Center;
    NPCMood mood = NPCMood.Happy;
    Rigidbody2D rb;
    [SerializeField] InkManager ink;
    [SerializeField] TextAsset InkJsonAsset;
    PlayerMovement pm;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public override void OnInteract(){
        ink.StartStory(InkJsonAsset);
    }
}
