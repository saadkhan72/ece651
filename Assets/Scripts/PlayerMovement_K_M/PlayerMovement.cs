using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public bool isStatic;

    [SerializeField] private LayerMask jumpableGround;


    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float ketchupPushForce = 10f;
    [SerializeField] private float moveSpeedOnMustard = 14f;

    [SerializeField] private AudioSource runsoundEffect;
    [SerializeField] private AudioSource jumpsoundEffect;


    private enum MovementState { idle, running, jumping, falling }

    private bool isInKetchup = false;
    private bool isOnMustard = false;
    private bool isInMustardState = false;
    private bool isOnGround = true;




    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        SetMovementRb();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        SetAnim();
        //anim = GetComponent<Animator>();
        isStatic = false;
    }

    // Update is called once per frame
    private void Update()
    {

        //float dirX = Input.GetAxis("Horizontal");
        SetMovementDirX(Input.GetAxisRaw("Horizontal"));
        //dirX = Input.GetAxisRaw("Horizontal");

        if (isInMustardState && !isStatic)
        {
            GetMovementRb().velocity = new Vector2(GetMovementDirX() * moveSpeedOnMustard, GetMovementRb().velocity.y);
        }
        else if (!isStatic)
        {
            GetMovementRb().velocity = new Vector2(GetMovementDirX() * moveSpeed, GetMovementRb().velocity.y);
        }


        // if (Input.GetKeyDown("space"))
        if (Input.GetButtonDown("Jump") && (IsGrounded() || isInKetchup) && !isStatic)
        {
            jumpsoundEffect.Play();
            GetMovementRb().velocity = new Vector3(GetMovementRb().velocity.x, jumpForce);
        }



        UpdateAnimationState();
    }


    public void UpdateAnimationState()
    {
        MovementState state;


        if (GetMovementDirX() > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (GetMovementDirX() < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (!isStatic)
        {
            if (GetMovementRb().velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (GetMovementRb().velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
        }


        GetAnim().SetInteger("state", (int)state);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);  
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ketchup") && !isStatic)
        {
            isInKetchup = true;
            GetMovementRb().velocity = new Vector3(GetMovementRb().velocity.x, GetMovementRb().velocity.y + ketchupPushForce);
        }

        if (collision.gameObject.CompareTag("Mustard"))
        {
            isOnMustard = true;
            isInMustardState = true;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ketchup"))
        {
            isInKetchup = false;
        }

        if (collision.gameObject.CompareTag("Mustard"))
        {
            isOnMustard = false;

            if (isOnGround)
            {
                isInMustardState = false;
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (isOnMustard)
            {
                isInMustardState = true;
            }
            else 
            {
                isInMustardState = false;
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }

    }

    private void playRunSound()
    {
        runsoundEffect.Play();
    }

    public void SetMovementDirX(float thisDirx)
    {
        dirX = thisDirx;
    }


    public float GetMovementDirX()
    {
        return dirX;
    }

    public void SetMovementRb()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Rigidbody2D GetMovementRb()
    {
        return rb;
    }

    public Animator GetAnim()
    {
        return anim;
    }

    public void SetAnim()
    {
        anim = GetComponent<Animator>();
    }

    public void SetRBvelocity(Vector2 input)
    {
        GetMovementRb().velocity = input;
    }

}
