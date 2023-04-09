using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerLifeTests
{
    private Scene tempTestScene;
    private string sceneToTest = "Level0";
    private GameObject player;
    private Animator anim;
    private GameObject trap;
    private GameObject sway;


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }

    [UnityTest]
    public IEnumerator MapBorderDieTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerLife>();
        anim = player.GetComponent<Animator>();

        //user story when collide with map border
        player.transform.position = new Vector3(86f, -24f, -1.6f);
        yield return new WaitForSeconds(1f);
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Assert.AreEqual("Ham_Die", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }


    [UnityTest]
    public IEnumerator TrapDieTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerLife>();
        anim = player.GetComponent<Animator>();

        trap = GameObject.FindGameObjectsWithTag("Trap")[0];
        Vector3 traploc = trap.transform.position;

        player.transform.position = traploc;
        yield return new WaitForSeconds(0.5f);
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Assert.AreEqual("Ham_Die", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }

    

   


    [UnityTest]
    public IEnumerator AntDieTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerLife>();
        anim = player.GetComponent<Animator>();

        trap = GameObject.FindGameObjectsWithTag("Ant")[0];
        Vector3 traploc = trap.transform.position;

        player.transform.position = traploc;
        yield return new WaitForSeconds(0.5f);
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Assert.AreEqual("Ham_Die", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }


    [UnityTest]
    public IEnumerator SawydownDieTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerLife>();
        anim = player.GetComponent<Animator>();

        sway = GameObject.FindGameObjectsWithTag("SwayDown")[0];
        Vector3 traploc = sway.transform.position;

        player.transform.position = traploc;
        yield return new WaitForSeconds(0.5f);
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Assert.AreEqual("Ham_Die", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }


    [UnityTest]
    public IEnumerator FlyStunTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerLife>();
        anim = player.GetComponent<Animator>();

        trap = GameObject.FindGameObjectsWithTag("Stun")[0];
        Vector3 traploc = trap.transform.position;

        player.transform.position = traploc;
        yield return new WaitForSeconds(0.5f);
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Assert.AreEqual("Ham_Stun", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }
}
