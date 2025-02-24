using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource speaker1;
    [SerializeField] AudioSource speaker2;
    [SerializeField] AudioClip morning;
    [SerializeField] AudioClip afternoon;
    [SerializeField] AudioClip evening;
    private bool primarySpeaker = true;
    [SerializeField] int time = 0;
    int currentClip = 1;

    void Start(){
        speaker1.clip = morning;
        currentClip = 1;
        primarySpeaker = true;
        speaker1.time = 70;
        speaker1.Play();
    }

    void Update(){
        if(primarySpeaker){
            if(time <= 3 && speaker1.time >= 80 && currentClip == 1){
                speaker2.clip = morning;
                speaker2.time = 6;
                speaker2.Play();
                primarySpeaker = false;
            }else if(time <= 6 && ((speaker1.time >= 80 && currentClip == 1) || (speaker1.time >= 70 && currentClip == 2))){
                speaker2.clip = afternoon;
                speaker2.time = (currentClip == 1) ? 0 : 6;
                currentClip = 2;
                speaker2.Play();
                primarySpeaker = false;
            }
        }else{
            if(time <= 3 && speaker2.time >= 80 && currentClip == 1){
                speaker1.clip = morning;
                speaker1.time = 6;
                speaker1.Play();
                primarySpeaker = true;
            }else if(time <= 6 && ((speaker2.time >= 80 && currentClip == 1) || (speaker2.time >= 70 && currentClip == 2))){
                speaker1.clip = afternoon;
                speaker1.time = (currentClip == 1) ? 0 : 6;
                currentClip = 2;
                speaker1.Play();
                primarySpeaker = true;
            }
        }
    }
}
