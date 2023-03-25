using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ant : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    public float speed;
    private float leftx, rightx;
    private bool faceleft = true;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (faceleft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceleft = false;
                //anim.SetFloat("running", Mathf.Abs(1));
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceleft = true;
            }
        }
    }
}
