using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject main_menu;
    [SerializeField] GameObject title_screen;
    [SerializeField] GameObject credits_screen;
    [SerializeField] GameObject name_input; 
    public PlayerData player_data;

    // Start is called before the first frame update
    void Start()
    {
        title_screen.SetActive(false);  
        credits_screen.SetActive(false);    
    }

    //Go to Title Screen
    public void ToTitle()
    {
        main_menu.SetActive(false);
        title_screen.SetActive(true);
    }

    public void ToCredits()
    {
        main_menu.SetActive(false); 
        credits_screen.SetActive(true); 
    }

    //Go to Main Scene (for Pause Menu)
    public void MainScene()
    {
        title_screen.SetActive(false);
        credits_screen.SetActive(false);
        main_menu.SetActive(true);

        SceneManager.LoadScene("Nandni_Menu");
    }

    //Go to Main Page 
    public void MainPage()
    {
        credits_screen.SetActive(false);
        main_menu.SetActive(true);

    }

    //Load Saved Game
    public void LoadGame()
    {

    }

    //Quit Application
    public void Quit()
    {
        Application.Quit();
    }

    //Start New Game
    public void NewGame()
    {
        //player_data.SetName();
        //Debug.Log(name_input.);

        SceneManager.LoadScene("Nandni_Test");
    }



}
