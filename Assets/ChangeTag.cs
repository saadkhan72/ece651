using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTag : MonoBehaviour
{
    [SerializeField] private GameObject hamburger;
    public void ChangePlayerTag()
    {
        hamburger.tag = "Untagged";
    }


    private void EndLoadStart()
    {
        SceneManager.LoadScene(0);
    }
}
