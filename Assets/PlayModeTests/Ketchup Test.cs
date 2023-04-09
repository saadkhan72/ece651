using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class KetchupTest
{
    private Scene tempTestScene;
    private string sceneToTest = "Level0";
    private GameObject player;
    private Animator anim;
    private Rigidbody2D rb;


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }


    [UnityTest]
    public IEnumerator KetchupPushTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerMovement>();
        anim = player.GetComponent<Animator>();
        GameObject ketchup = GameObject.FindWithTag("Ketchup");
        player.transform.position = ketchup.transform.position;
        yield return new WaitForSeconds(1f);
        rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 14f);
        var vel = rb.velocity;
        yield return new WaitForSeconds(0.2f);
        Assert.IsTrue(vel.y<player.GetComponent<Rigidbody2D>().velocity.y);


        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }


   
}
