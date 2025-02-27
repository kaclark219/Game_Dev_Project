using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{
    [SerializeField] NPCName NPCname;
    NPCPosition dir = NPCPosition.Center;
    NPCMood mood = NPCMood.Happy;
    SpriteRenderer sr;
    [SerializeField] InkManager ink;
    [SerializeField] TextAsset InkJsonAsset;
    PlayerMovement pm;

    private PlayerData playerData;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        sr = GetComponentInParent<SpriteRenderer>();
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

    public override void Update(){
        base.Update();
        if(active){
            if(pm.rb.position.y > transform.position.y){
                sr.sortingOrder = 4;
            }else{
                sr.sortingOrder = 2;
            }
        }
    }
}
