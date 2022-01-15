using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderer;

    private bool jumpClicked = false;
    private bool leftClicked = false;
    private bool rightClicked = false;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 14f;
    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;


    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        LeftRightMovement();

        JumpMovement();

        UpdateAnimationState();

    }

    /*
     * Handle left right movement for player ( Keyboard + UI Buttons )
     */
    private void LeftRightMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (leftClicked)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (rightClicked)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    /*
     * Handle jump movement for player ( Keyboard + UI Buttons )
     */
    private void JumpMovement()
    {
        if ((Input.GetButtonDown("Jump") || jumpClicked) && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpClicked = false;
        }
    }

    public void Jump()
    {
        jumpClicked = true;
    }
    public void MoveLeft()
    {
        leftClicked = true;
    }
    public void MoveRight()
    {
        rightClicked = true;
    }
    public void StopMoving()
    {
        leftClicked = false;
        rightClicked= false;
        rb.velocity = Vector2.zero;
    }

    /*
     * This Function Will Check If The Player Is Moving To Change His Animation
     */
    private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX > 0f || rightClicked)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f || leftClicked)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);

    }

    /*
     * This function will check if the player touches the ground 
     */
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
