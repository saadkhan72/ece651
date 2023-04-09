using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SawTest
{
    private Scene tempTestScene;
    private string sceneToTest = "Level0";
    private GameObject player;
    private GameObject saw;


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }


    [UnityTest]
    public IEnumerator SawRotateTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        saw = GameObject.Find("MovingPlatform");

        float old_angleZ = saw.transform.rotation.eulerAngles.z; //get the current rotation about z
        Debug.Log("[SawTest]: " + old_angleZ);


        yield return new WaitForSeconds(1/2);
        //yield return new WaitForSeconds(0.2f);
        //yield return new WaitForSeconds(5f);
        float new_angleZ = saw.transform.rotation.eulerAngles.z;//get the current rotation about z after 0.5 seconds
        Debug.Log("[SawTest]: "+new_angleZ);
        Assert.IsTrue(new_angleZ > old_angleZ); //if spinning cw, angle should be larger

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);


    }


     [UnityTest]
    public IEnumerator SawKillsPlayerTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        saw = GameObject.Find("MovingPlatform");

        float old_angleZ = saw.transform.rotation.eulerAngles.z; //get the current rotation about z
        Debug.Log("[SawTest]: " + old_angleZ);


        yield return new WaitForSeconds(1/2);
        //yield return new WaitForSeconds(0.2f);
        //yield return new WaitForSeconds(5f);
        float new_angleZ = saw.transform.rotation.eulerAngles.z;//get the current rotation about z after 0.5 seconds
        Debug.Log("[SawTest]: "+new_angleZ);
        Assert.IsTrue(new_angleZ > old_angleZ); //if spinning cw, angle should be larger

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);


    }
}
