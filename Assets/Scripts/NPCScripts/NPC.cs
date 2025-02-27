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
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        sr = GetComponentInParent<SpriteRenderer>();
    }

    public override void OnInteract(){
        ink.StartStory(InkJsonAsset);
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
