using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController lone;
    [SerializeField] private AnimatorOverrideController ltwo;
    [SerializeField] private AnimatorOverrideController lthree;
    [SerializeField] private AnimatorOverrideController lfour;
    [SerializeField] private AnimatorOverrideController lfive;

    private AnimatorOverrideController[] controllerArray;

    [SerializeField] private new GameObject light;
    [SerializeField] private GameObject player;
    private AudioSource goalReachSound;
    private bool activate;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        SetToppingController();
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        if (levelIndex == 2)
        {
            GetComponent<Animator>().runtimeAnimatorController = lone as RuntimeAnimatorController;
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = controllerArray[levelIndex - 3]  as RuntimeAnimatorController;
        }
        goalReachSound = GetComponent<AudioSource>();
        activate = false;
        Debug.Log(GetComponent<Animator>().runtimeAnimatorController.name);
    }


    public void SetToppingController()
    {
        controllerArray = new AnimatorOverrideController[] { ltwo, lthree, lfour, lfive };
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activate)
        {
            activate = true;
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(light);
            goalReachSound.Play();
            StartCoroutine(SkinChangeAnim());
            StartCoroutine(GoToNextLevel());
        }
    }


    IEnumerator SkinChangeAnim()
    {


        //change skin animation
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<PlayerMovement>().isStatic = true;
        player.GetComponent<Animator>().Play("Ham_Change");
        yield return new WaitForSeconds(5);

    }


    IEnumerator GoToNextLevel()
    {

        yield return new WaitForSeconds(2);
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
