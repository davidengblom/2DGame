using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float jumpTime;
    

    //Private Variables
    private float groundCheckRadius = 0.3f;
    private float jumpTimeCounter;
    private bool isGrounded;
    private bool isJumping;
    private bool jump;
    private Vector2 moveInput;
    private LayerMask groundLayer;


    //Components
    private Rigidbody2D rb;
    private Animator animator;
    private Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundCheck = GameObject.Find("GroundCheck").transform;
        groundLayer = LayerMask.GetMask("Ground");
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        //Jumping
        if(jump)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpHeight;
            jump = false;
        }

        //Animation Parametres
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        animator.SetBool("Grounded", isGrounded);
    }

    void Update()
    {
        //Check for ground collision and movement input
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        moveInput.x = Input.GetAxisRaw("Horizontal");

        //Check for jump input
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
}
