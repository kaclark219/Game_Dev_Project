using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject DialogUI;
    [SerializeField] private GameObject InventoryUI;
    [Space]
    [SerializeField] private PlayerMovement PlayerMovement;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        HUD.SetActive(false);
        DialogUI.SetActive(false);
        PauseUI.SetActive(false);
        InventoryUI.SetActive(false);
        DisableMovement();
        DisableInteract();
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        HUD.SetActive(true);
        EnableMovement();
        DisableInteract();
    }


    public void OpenDialogue()
    {
        DialogUI.SetActive(true);
        DisableMovement();
        DisableInteract();
    }

    public void CloseDialogue()
    {
        DialogUI.SetActive(false);
        EnableMovement();
        EnableInteract();
    }

    public void OpenPause()
    {
        PauseUI.SetActive(true);
        DisableMovement();
        DisableInteract();
    }

    public void ClosePause()
    {
        PauseUI.SetActive(false);
        EnableMovement();
        EnableInteract();
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        DisableMovement();
        DisableInteract();
    }

    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        EnableMovement();
        EnableInteract();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void EnableMovement()
    {
        PlayerMovement.enabled = true;
    }
    private void DisableMovement()
    {
        PlayerMovement.enabled = false;
    }

    private void EnableInteract()
    {
        PlayerMovement.EnableInteractor();
    }

    private void DisableInteract()
    {
        PlayerMovement.DisableInteractor();
    }
}
