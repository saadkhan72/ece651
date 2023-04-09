using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TheMainMenuTest
{
    private Scene tempTestScene;
    private string sceneToTest = "MainMenuSingleScene";
    private int mainMenuSceneIndex = 0;

    [SetUp]
    public void Setup()
    {
       SceneManager.LoadScene(mainMenuSceneIndex);
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var scene in SceneManager.GetAllScenes()) {
            SceneManager.UnloadScene(scene);
        }
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator MainMenuSceneIsLoaded()
    {
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo(sceneToTest));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCanSelectAnyLevelWhenLevelsButtonIsPressed()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
        int total_levels = 5;
        int level_1_index = 1;

        //wait for a few seconds
        //check if the level we randomly selected is the actual level that is loaded
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        //randomly selected a valid level
        string selected_level = Random.Range(level_1_index, total_levels+1).ToString();
        string level_to_select = "Level" + selected_level;
        Button level_to_select_btn = GameObject.Find(level_to_select).GetComponent<Button>();
        level_to_select_btn.onClick.Invoke();

        //check if the level we randomly selected is the actual level that is loaded
        secondsToWait = 2;
        yield return new WaitForSeconds(secondsToWait);
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo("Level "+selected_level));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCanSelectLevel1WhenLevel1ButtonIsPressed()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
        int total_levels = 5;
        int level_1_index = 1;

        //wait for a few seconds
        //check if the level we randomly selected is the actual level that is loaded
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        //randomly selected a valid level
        string selected_level = "1";
        string level_to_select = "Level" + selected_level;
        Button level_to_select_btn = GameObject.Find(level_to_select).GetComponent<Button>();
        level_to_select_btn.onClick.Invoke();

        //check if the level we randomly selected is the actual level that is loaded
        secondsToWait = 2;
        yield return new WaitForSeconds(secondsToWait);
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo("Level " + selected_level));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCanSelectLevel2WhenLevel2ButtonIsPressed()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
        int total_levels = 5;
        int level_1_index = 1;

        //wait for a few seconds
        //check if the level we randomly selected is the actual level that is loaded
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        //randomly selected a valid level
        string selected_level = "2";
        string level_to_select = "Level" + selected_level;
        Button level_to_select_btn = GameObject.Find(level_to_select).GetComponent<Button>();
        level_to_select_btn.onClick.Invoke();

        //check if the level we randomly selected is the actual level that is loaded
        secondsToWait = 2;
        yield return new WaitForSeconds(secondsToWait);
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo("Level " + selected_level));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCanSelectLevel3WhenLevel3ButtonIsPressed()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
        int total_levels = 5;
        int level_1_index = 1;

        //wait for a few seconds
        //check if the level we randomly selected is the actual level that is loaded
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        //randomly selected a valid level
        string selected_level = "3";
        string level_to_select = "Level" + selected_level;
        Button level_to_select_btn = GameObject.Find(level_to_select).GetComponent<Button>();
        level_to_select_btn.onClick.Invoke();

        //check if the level we randomly selected is the actual level that is loaded
        secondsToWait = 2;
        yield return new WaitForSeconds(secondsToWait);
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo("Level " + selected_level));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCanSelectLevel4WhenLevel4ButtonIsPressed()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
        int total_levels = 5;
        int level_1_index = 1;

        //wait for a few seconds
        //check if the level we randomly selected is the actual level that is loaded
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        //randomly selected a valid level
        string selected_level = "4";
        string level_to_select = "Level" + selected_level;
        Button level_to_select_btn = GameObject.Find(level_to_select).GetComponent<Button>();
        level_to_select_btn.onClick.Invoke();

        //check if the level we randomly selected is the actual level that is loaded
        secondsToWait = 2;
        yield return new WaitForSeconds(secondsToWait);
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo("Level " + selected_level));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCanSelectLevel5WhenLevel5ButtonIsPressed()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
        int total_levels = 5;
        int level_1_index = 1;

        //wait for a few seconds
        //check if the level we randomly selected is the actual level that is loaded
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        //randomly selected a valid level
        string selected_level = "5";
        string level_to_select = "Level" + selected_level;
        Button level_to_select_btn = GameObject.Find(level_to_select).GetComponent<Button>();
        level_to_select_btn.onClick.Invoke();

        //check if the level we randomly selected is the actual level that is loaded
        secondsToWait = 2;
        yield return new WaitForSeconds(secondsToWait);
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo("Level " + selected_level));
        yield return null;
    }

    [UnityTest]
    public IEnumerator CanGoBackToMainMenuAfterClickingOnTheLevelsButtonInMainMenu()
    {
        //click on the levels button on the main menu screen
        Button levels_button = GameObject.Find("Levels").GetComponent<Button>();
        levels_button.onClick.Invoke();
       
        //wait for scene to load
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);

        // Click on Home Icon
        Button home_btn = GameObject.Find("Home").GetComponent<Button>();
        home_btn.onClick.Invoke();
        
        //wait for scene to load
        secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);
       
        //check whether we are at the main menu
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo(sceneToTest));
        yield return null;
    }


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HelpIsLoadedWhenHelpButtonIsPressed()
    {
        Button help_button = GameObject.Find("HelpButton").GetComponent<Button>();
        help_button.onClick.Invoke();
        
        //wait for scene to load
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);
        
        Scene scene = SceneManager.GetActiveScene();

        var help_menu = GameObject.Find("HelpMenu");
        Assert.That(help_menu != null);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CanGoBackToMainMenuAfterSelectingHelpOnMainMenu()
    {
        //click on help button
        Button help_button = GameObject.Find("HelpButton").GetComponent<Button>();
        help_button.onClick.Invoke();
        
        //wait for scene to load
        int secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);
        
        // Click on Home Icon
        Button home_btn = GameObject.Find("Home").GetComponent<Button>();
        home_btn.onClick.Invoke();
        
        //wait for scene to load
        secondsToWait = 1;
        yield return new WaitForSeconds(secondsToWait);
       
        //check whether we are at the main menu
        Scene scene = SceneManager.GetActiveScene();
        Assert.That(scene.name, Is.EqualTo(sceneToTest));
        yield return null;
    }
}
