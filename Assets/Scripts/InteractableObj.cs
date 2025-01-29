using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [SerializeField] private GameObject Popup;

    private void Start()
    {
        Popup.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<PlayerInteractor>().enabled)
        {
            StartInteraction();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EndInteraction();
        }
    }

    virtual public void StartInteraction()
    {
        Popup.SetActive(true);

    }

    virtual public void EndInteraction()
    {
        Popup.SetActive(false);
    }


}
