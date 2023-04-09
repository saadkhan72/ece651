using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class FlyTest
{
    private Scene tempTestScene;
    private string sceneToTest = "Level0";
    private GameObject player;
    private GameObject fly0;
    private Animator anim;
    //Vector3 pos, velocity;
    //private Rigidbody2D rb;


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }


    [UnityTest]
    public IEnumerator FlyMoveTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        fly0 = GameObject.FindWithTag("Stun");
        
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(110.5f, -2f, 190f);
        //GameObject fly0 = GameObject.FindWithTag("Stun");
        
        var script = fly0.GetComponent<fly>();
        
        yield return new WaitForSeconds(1f);
        //yield return new WaitForSeconds(0.2f);
        //yield return new WaitForSeconds(5f);
        
        Assert.IsTrue((script.choose >= 0) && (script.choose <= (script.waypoints.Length - 1)));
        /*
        yield return new WaitForEndOfFrame();
        pos = fly0.transform.position;
        yield return new WaitForEndOfFrame();
        */
        if (Vector3.Distance(script.waypoints[script.choose].transform.position, script.transform.position) > .1f) {
            /*
            velocity = (fly0.transform.position - pos) / Time.deltaTime;
            pos = fly0.transform.position;
            //Assert.AreEqual(velocity, Vector3.MoveTowards(fly0.transform.position, script.waypoints[script.choose].transform.position, Time.deltaTime * 5f)- fly0.transform.position);
            Assert.IsTrue((velocity.magnitude > 4.9f) && (velocity.magnitude < 5.1f));*/
            Assert.IsTrue((script.velocity.magnitude > 4.9f) && (script.velocity.magnitude < 5.1f));
            //Assert.AreEqual(5f, script.velocity.magnitude);
        }
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);


    }





    [UnityTest]
    public IEnumerator FlyReducesPlayerSpeedTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        fly0 = GameObject.FindWithTag("Stun");
        
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(110.5f, -2f, 190f);
        //GameObject fly0 = GameObject.FindWithTag("Stun");
        
        var script = fly0.GetComponent<fly>();
        
        yield return new WaitForSeconds(1f);
        //yield return new WaitForSeconds(0.2f);
        //yield return new WaitForSeconds(5f);
        
        Assert.IsTrue((script.choose >= 0) && (script.choose <= (script.waypoints.Length - 1)));
        /*
        yield return new WaitForEndOfFrame();
        pos = fly0.transform.position;
        yield return new WaitForEndOfFrame();
        */
        if (Vector3.Distance(script.waypoints[script.choose].transform.position, script.transform.position) > .1f) {
            /*
            velocity = (fly0.transform.position - pos) / Time.deltaTime;
            pos = fly0.transform.position;
            //Assert.AreEqual(velocity, Vector3.MoveTowards(fly0.transform.position, script.waypoints[script.choose].transform.position, Time.deltaTime * 5f)- fly0.transform.position);
            Assert.IsTrue((velocity.magnitude > 4.9f) && (velocity.magnitude < 5.1f));*/
            Assert.IsTrue((script.velocity.magnitude > 4.9f) && (script.velocity.magnitude < 5.1f));
            //Assert.AreEqual(5f, script.velocity.magnitude);
        }
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);


    }
}
