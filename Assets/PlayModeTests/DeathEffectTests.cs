using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class DeathEffectTests
{
    private Scene tempTestScene;
    private Animator fadeAnimator;
    private string sceneToTest = "Level0";
    private GameObject deathCanvas;


    [SetUp]
    public void Setup()
    {
        tempTestScene = SceneManager.GetActiveScene();
    }


    [UnityTest]
    public IEnumerator InitialFadeInTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        fadeAnimator = GameObject.FindWithTag("DeathEffectCanvas").GetComponent<Animator>();
        string expectedAnimationState = "FadeIn";
        yield return null;

        AnimatorClipInfo[] currentClipInfo = fadeAnimator.GetCurrentAnimatorClipInfo(0);
        string curAnimationState = currentClipInfo[0].clip.name;

        //Debug.Log(expectedAnimationState);
        //Debug.Log(curAnimationState);
        Assert.AreEqual(expectedAnimationState, curAnimationState);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }


    [UnityTest]
    public IEnumerator LightFadeTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        fadeAnimator = GameObject.FindWithTag("DeathEffectCanvas").GetComponent<Animator>();
        string expectedAnimationState = "FadeIn";
        yield return null;

        AnimatorClipInfo[] currentClipInfo = fadeAnimator.GetCurrentAnimatorClipInfo(0);
        string curAnimationState = currentClipInfo[0].clip.name;

        //Debug.Log(expectedAnimationState);
        //Debug.Log(curAnimationState);
        Assert.AreEqual(expectedAnimationState, curAnimationState);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }

    


    [UnityTest]
    public IEnumerator DeathFadeOutTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        deathCanvas = GameObject.FindWithTag("DeathEffectCanvas");
        fadeAnimator = deathCanvas.GetComponent<Animator>();
        yield return new WaitForSeconds(2);
        deathCanvas.GetComponent<DeathEffect>().startFadeOutAnim = true;
        string expectedAnimationState = "FadeOut";
        yield return new WaitForSeconds(0.5f);

        AnimatorClipInfo[] currentClipInfo = fadeAnimator.GetCurrentAnimatorClipInfo(0);
        string curAnimationState = currentClipInfo[0].clip.name;

        //Debug.Log(expectedAnimationState);
        //Debug.Log(curAnimationState);
        Assert.AreEqual(expectedAnimationState, curAnimationState);

        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }
}
