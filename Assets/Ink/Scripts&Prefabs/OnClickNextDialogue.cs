using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickNextDialogue : Button
{
    [SerializeField] private InkManager InkManager;
    protected override void Start()
    {
        base.Start();
        if (InkManager == null)
        {
            InkManager = GameObject.Find("InkManager").GetComponent<InkManager>();
        }
    }

    override public void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        InkManager.DisplayNextLine();
    }
}
