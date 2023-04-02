using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChangeLevelText : MonoBehaviour
{
    [SerializeField] private Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        string name = SceneManager.GetActiveScene().name;
        levelText.text = name;
    }

    
}
