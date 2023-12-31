using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private AudioSource JumpSound;

    [SerializeField]
    private float jumpPower = 14f;

    [SerializeField]
    private float moveSpeed = 7f;
    private float dirx;
    private SpriteRenderer Sprite;


    [SerializeField]
    private LayerMask Ground;

    private int JumpCounter;


    private enum MovementState { Idle, Running, Jumping, Falling };

    private Rigidbody2D rb;

    private Animator anim;

    private BoxCollider2D bcol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        bcol = GetComponent<BoxCollider2D>();
        JumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && JumpCounter <= 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            JumpSound.Play();
            JumpCounter++;
        }

        if(IsGrounded() && JumpCounter == 2)
        {
            JumpCounter = 0;
        }
        DoAnimations();

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bcol.bounds.center, bcol.bounds.size, 0f, Vector2.down, 0.1f, Ground);
    }

    private void DoAnimations()
    {
        MovementState State;

        if (dirx > 0f)
        {
            State = MovementState.Running;
            Sprite.flipX = false;

        }
        else if (dirx < 0f)
        {
            State = MovementState.Running;
            Sprite.flipX = true;
        }
        else
        {
            State = MovementState.Idle;

        }
        if(rb.velocity.y > 0.1f)
        {
            State = MovementState.Jumping;
        }
        else if(rb.velocity.y < -0.1f)
        {
            State = MovementState.Falling;
        }
        anim.SetInteger("State", (int)State);
    }
}
