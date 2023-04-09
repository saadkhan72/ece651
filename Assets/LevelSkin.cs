using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSkin : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController levelzero;
    [SerializeField] private AnimatorOverrideController levelfive;
    [SerializeField] private AnimatorOverrideController levelone;
    [SerializeField] private AnimatorOverrideController leveltwo;
    [SerializeField] private AnimatorOverrideController levelthree;
    [SerializeField] private AnimatorOverrideController levelfour;

    private AnimatorOverrideController[] controllerArray;
    private int sceneIndex;
    private Animator anim;

    void Start()
    {
        
        anim = GetComponent<Animator>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SetSkinChangeController();
        if (sceneIndex == 7 || sceneIndex == 8)
        {
            GetComponent<Animator>().runtimeAnimatorController = levelzero as RuntimeAnimatorController;
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = GetSkinChangeController(sceneIndex - 1) as RuntimeAnimatorController;
        }
        
    }



    public AnimatorOverrideController GetSkinChangeController(int skinIndex)
    {
        return controllerArray[skinIndex - 1];
    }


    public void SetSkinChangeController()
    {
        controllerArray = new AnimatorOverrideController[] { levelone, leveltwo, levelthree, levelfour, levelfive };
    }




}
