using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class KnifeTest
{
    private Scene tempTestScene;
    private string sceneToTest = "Level0";


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }




    [UnityTest]
    public IEnumerator KnifeAlwaysGoDown()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest)); 
        
        GameObject knife = GameObject.Instantiate(Resources.Load("Prefabs/Knife_prefab/Knife") as GameObject);
        var originalPosition = knife.transform.position.y;
        yield return new WaitForFixedUpdate();
        // Assert
        Assert.That(originalPosition, Is.GreaterThan(knife.transform.position.y));
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }
}
