using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{

    [SerializeField] private GameObject Popup;
    public bool active = false;
    [SerializeField] protected PlayerInteractor plint;
    public float frame = 0;

    protected void Start()
    {
        Popup.SetActive(false);
        plint = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInteractor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<PlayerInteractor>().enabled)
        {
            plint.list.Add(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            plint.list.Remove(this);
            active = false;
        }
    }

    void Update()
    {
        if (active){
            Popup.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                OnInteract();
            }
        }else{
            Popup.SetActive(false);
        }
    }

    public virtual void OnInteract(){}
}
