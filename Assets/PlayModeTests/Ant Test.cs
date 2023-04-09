using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class AntTest
{
    private Scene tempTestScene;
    private string sceneToTest = "Level0";
    private GameObject player;
    private GameObject ant0;
    private Animator anim;
    Vector3 pos, velocity;

    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }

    [UnityTest]
    public IEnumerator AntMoveTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        ant0 = GameObject.FindWithTag("Ant");
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(39f, 0f, 0f);
        
        var script = ant0.GetComponent<ant>();
        //yield return new WaitForSeconds(0.2f);
        var originalPosition = ant0.transform.position.x;
        //yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(.1f);
        //yield return new WaitForSeconds(5f);
        // Assert
        Assert.That(originalPosition, Is.GreaterThan(ant0.transform.position.x));
        yield return new WaitForSeconds(3f);
        originalPosition = ant0.transform.position.x;
        yield return new WaitForSeconds(.1f);
        Assert.That(originalPosition, Is.LessThan(ant0.transform.position.x));
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }


    [UnityTest]
    public IEnumerator AntKillsPlayerTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        ant0 = GameObject.FindWithTag("Ant");
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(39f, 0f, 0f);
        
        var script = ant0.GetComponent<ant>();
        //yield return new WaitForSeconds(0.2f);
        var originalPosition = ant0.transform.position.x;
        //yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(.1f);
        //yield return new WaitForSeconds(5f);
        // Assert
        Assert.That(originalPosition, Is.GreaterThan(ant0.transform.position.x));
        yield return new WaitForSeconds(3f);
        originalPosition = ant0.transform.position.x;
        yield return new WaitForSeconds(.1f);
        Assert.That(originalPosition, Is.LessThan(ant0.transform.position.x));
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }
}
