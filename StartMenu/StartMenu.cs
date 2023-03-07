using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(8);
    }
    public void LoadMainMenu()
    {
        //SceneManager.LoadScene("MainMenuSingleScene"); //name of scene to load
        SceneManager.LoadScene(0);
    }
    public void LoadHelp()
    {
        SceneManager.LoadScene("HelpMenu");
    }
    public void Level1()
    {
        SceneManager.LoadScene(2); //assuming levels are in build settings as lvl1=1, lvl2=2...
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
    public void Level4()
    {
        SceneManager.LoadScene(5);
    }
    public void Level5()
    {
        SceneManager.LoadScene(6);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
