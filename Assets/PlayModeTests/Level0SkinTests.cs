using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Level0SkinTests
{
    private Scene tempTestScene; 
    private string sceneToTest = "Level0";
    private GameObject player;
    private Animator anim;


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }


    [UnityTest]
    public IEnumerator SkinChangeTest()
    {
        //yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<LevelZeroSkinChange>();
        script.SetSkinChangeController();
        anim = player.GetComponent<Animator>();

        //test default skin
        //Debug.Log(anim.runtimeAnimatorController.name);
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        Assert.AreEqual("Hamburger", anim.runtimeAnimatorController.name);

        //test level 1 skin
        script.ChangeCharSkin(1);
        yield return null;
        Assert.AreEqual("Level1Override", anim.runtimeAnimatorController.name);

        //test level 2 skin
        script.ChangeCharSkin(2);
        yield return null;
        Assert.AreEqual("Level2Override", anim.runtimeAnimatorController.name);

        //test level 3 skin
        script.ChangeCharSkin(3);
        yield return null;
        Assert.AreEqual("Level3Override", anim.runtimeAnimatorController.name);

        //test level 4 skin
        script.ChangeCharSkin(4);
        yield return null;
        Assert.AreEqual("Level4Override", anim.runtimeAnimatorController.name);

        //test level 5 skin
        script.ChangeCharSkin(5);
        yield return null;
        Assert.AreEqual("Level5Override", anim.runtimeAnimatorController.name);
        //Assert.AreEqual("5_Idle", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }
}
