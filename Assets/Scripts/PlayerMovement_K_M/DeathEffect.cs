using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEffect : MonoBehaviour
{
    private Animator animator;
    public bool startFadeOutAnim;
    void Start()
    {
        //Debug.Log("finish loading scene=restart");
        startFadeOutAnim = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startFadeOutAnim)
        {
            FadeOutToRestart();
        }
    }

    public void FadeOutToRestart()
    {
        animator.SetTrigger("FadeOut");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
