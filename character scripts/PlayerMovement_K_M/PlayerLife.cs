using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float timerSpeed = 2f;
    private float count = 0f;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private AudioSource deathsoundEffect;
    [SerializeField] private AudioSource stunsoundEffect;
    [SerializeField] private GameObject bgm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (anim.GetBool("isP") == true)
        {
            count += Time.deltaTime;
            if (GetComponent<PlayerMovement>().IsGrounded() == false)
            {
                transform.position += new Vector3(0f, -0.01f, 0f);
            }
            if (count >= timerSpeed)
            {
                count = 0f;
                anim.SetBool("isP", false);
                rb.bodyType = RigidbodyType2D.Dynamic;
                GetComponent<PlayerMovement>().isStatic = false;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MapBorder"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("SwayDown") || collision.gameObject.CompareTag("LeftRight"))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")|| collision.gameObject.CompareTag("Ant"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Stun"))
        {
            //Destroy(collision.gameObject);
            Stun();
        }

    }

    private void Die()
    {
        bgm.GetComponent<AudioSource>().Pause();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().isStatic = true;
        }
        //deathsoundEffect.Play();
        anim.SetTrigger("death");
    }

    private void Stun()
    {
        stunsoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerMovement>().isStatic = true;
        anim.SetTrigger("stun");
        anim.SetBool("isP", true);
    }

    private void callDeathSFX()
    {
        deathsoundEffect.Play();
    }

    private void callDeathFade()
    {
        deathEffect.GetComponent<DeathEffect>().startFadeOutAnim = true;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public Animator GetPlayerLifeAnim()
    {
        return anim;
    }

    public void SetPlayerLifeAnim(Animator thisanim)
    {
        anim = thisanim;
    }
}
