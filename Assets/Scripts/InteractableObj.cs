using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{

    [SerializeField] private GameObject Popup;
    public bool PressAndHold = false;
    private bool interacting = false;
    private bool keyPressed = false;

    private void Start()
    {
        Popup.SetActive(false);
    }

    private void Update()
    {
        if (interacting)
        {
            if (Input.GetKeyDown(KeyCode.E) && !keyPressed)
            {
                keyPressed = true;
                StartInteraction();
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                keyPressed = false;
                EndInteraction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<PlayerInteractor>().enabled)
        {
            Popup.SetActive(true);
            interacting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Popup.SetActive(false);
            interacting = false;
        }
    }

    virtual public void StartInteraction()
    {
        Debug.Log("Start");

    }

    virtual public void EndInteraction()
    {
        Debug.Log("End");
    }

}