
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 3.0f;
    private GameObject knifeobj;
    Vector2 movement = new Vector2();
    public int rot_angle = 0;
    public bool go_back = true;
    private Vector3 orig_position;
    [SerializeField] private AudioSource soundeffect;

    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        knifeobj = this.gameObject;
        if (soundeffect != null)
        {
            soundeffect.Play();
        }
        knifeobj.transform.rotation = Quaternion.Euler(Vector3.forward * (rot_angle));
        orig_position = knifeobj.transform.position;
    }

    private void FixedUpdate()
    {
        movement.y -= 1;
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;

        if (rot_angle >= 30)
        {
            go_back = true;
        }

        if (go_back == true)
        {
            rot_angle -= 1;
        }

        if (rot_angle < -30)
        {
            go_back = false;
        }

        if (go_back == false)
        {
            rot_angle += 1;
        }

        knifeobj.transform.rotation = Quaternion.Euler(Vector3.forward * (rot_angle));

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //On TriggerEnter2D is for when we collide we something for the first time
    //so that will be if you want the knife to disappear as soon as it collides with something
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Logic for collision goes here. 
        if ((collision.gameObject.tag == "Ground") | (collision.gameObject.tag=="MapBorder"))
        {
            knifeobj.transform.position = orig_position;
            if (soundeffect != null)
            {
                soundeffect.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
