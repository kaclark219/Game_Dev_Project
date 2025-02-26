using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{
    [SerializeField] NPCName NPCname;
    NPCPosition dir = NPCPosition.Center;
    NPCMood mood = NPCMood.Happy;
    Rigidbody2D rb;
    [SerializeField] InkManager ink;
    [SerializeField] TextAsset InkJsonAsset;
    PlayerMovement pm;

    private PlayerData playerData;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        ink = GameObject.Find("InkManager").GetComponent<InkManager>();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        ink.StartStory(InkJsonAsset, this);
    }

    public override void EndInteract()
    {
        base.EndInteract();
        playerData.ModifyEnergy(-5); // Decrease player energy
    }
}
