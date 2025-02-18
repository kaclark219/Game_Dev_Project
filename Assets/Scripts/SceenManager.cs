using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject main_menu;
    [SerializeField] GameObject title_screen;
    [SerializeField] GameObject credits_screen;
    public TMP_InputField name_input;
    public string player_name = " "; 

    // Start is called before the first frame update
    void Start()
    {   
        name_input.onValueChanged.AddListener(UpdateUserInput);
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
        //main_menu.SetActive(false); 
        //credits_screen.SetActive(true); 
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
        GameObject tag_finder = GameObject.FindWithTag("Player_Name"); ;
        tag_finder.name = player_name; 
        DontDestroyOnLoad(tag_finder);
        Debug.Log(player_name);
        SceneManager.LoadScene("Nandni_Test");
    }

    //Set Player Name
    void UpdateUserInput(string input)
    {
        player_name = input; // Store the input text
        //Debug.Log("User Input: " + player_name);
    }


}
