using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerMovementTests
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
    public IEnumerator AnimationStateTests()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerMovement>();
        anim = player.GetComponent<Animator>();
        var curloc = player.transform.position;

        //test idle
        //script.SetMovementDirX(0f);
        script.SetMovementRb();
        script.SetAnim();
        script.UpdateAnimationState();
        yield return new WaitForFixedUpdate();
        Assert.AreEqual("Ham_Idle", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        //test running
        script.isStatic = false;
        script.SetMovementDirX(-1f);//toward left
        script.SetRBvelocity(new Vector2(0f, 0f));
        script.UpdateAnimationState();
        Assert.AreEqual(1, anim.GetInteger("state"));

        script.isStatic = false;
        script.SetMovementDirX(1f);//toward right
        script.SetRBvelocity(new Vector2(0f, 0f));
        script.UpdateAnimationState();
        Assert.AreEqual(1, anim.GetInteger("state"));

        //test jumping
        script.SetMovementDirX(0f);
        script.SetRBvelocity(new Vector2(0f, 1f));
        script.UpdateAnimationState();
        Assert.AreEqual(2, anim.GetInteger("state"));
        //yield return null;
        //Assert.AreEqual("Ham_Jump", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        //test falling
        player.transform.position += Vector3.up * 20;
        script.UpdateAnimationState();
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual("Ham_Fall", anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }


    [UnityTest]
    public IEnumerator IsGroundedTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerMovement>();
        anim = player.GetComponent<Animator>();

        //test IsGrounded  = true
        script.SetMovementDirX(0f);
        script.SetMovementRb();
        script.SetAnim();
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual(true, script.IsGrounded());


        //test IsGrounded  = false
        player.transform.position += Vector3.up * 20;
        yield return null;
        Assert.AreEqual(false, script.IsGrounded());

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }


    [UnityTest]
    public IEnumerator MustardTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerMovement>();
        var origV = player.GetComponent<Rigidbody2D>().velocity;
        var expectedVx = origV.x * 14f;
        var expectedVy = origV.y;
        anim = player.GetComponent<Animator>();
        GameObject mustard = GameObject.FindWithTag("Mustard");
        player.transform.position = mustard.transform.position;
        yield return new WaitForSeconds(1);
        Assert.AreEqual(expectedVx, player.GetComponent<Rigidbody2D>().velocity.x);
        Assert.AreEqual(expectedVy, player.GetComponent<Rigidbody2D>().velocity.y);


        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }


    [UnityTest]
    public IEnumerator MustardSlidesPlayerTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        player = GameObject.FindWithTag("Player");
        var script = player.GetComponent<PlayerMovement>();
        var origV = player.GetComponent<Rigidbody2D>().velocity;
        var expectedVx = origV.x * 14f;
        var expectedVy = origV.y;
        anim = player.GetComponent<Animator>();
        GameObject mustard = GameObject.FindWithTag("Mustard");
        player.transform.position = mustard.transform.position;
        yield return new WaitForSeconds(1);
        Assert.AreEqual(expectedVx, player.GetComponent<Rigidbody2D>().velocity.x);
        Assert.AreEqual(expectedVy, player.GetComponent<Rigidbody2D>().velocity.y);


        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);

    }

}
