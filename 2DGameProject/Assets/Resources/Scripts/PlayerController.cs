using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Audio clips
    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip walkSound;

    //Public variables
    [Header("Variables")]
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float jumpTime;
    

    //Private variables
    private float groundCheckRadius = 0.3f;
    private float jumpTimeCounter;
    private bool isGrounded;
    private bool isJumping;
    private bool doJump;
    private Vector2 moveInput;
    private LayerMask groundLayer;


    //Components
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;
    private Transform groundCheck;

    void Start()
    {
        //Assign components & variables
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        groundCheck = GameObject.Find("GroundCheck").transform;
        groundLayer = LayerMask.GetMask("Ground");
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        //Jumping
        if(doJump)
        {
            //Play the jump sound
            audioSource.clip = jumpSound;
            audioSource.Play();

            //Have the player jump
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpHeight;
            doJump = false;
        }

        //Animation parametres
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
            doJump = true;
        }

        //Check if jump button is held down after jumping
        if(Input.GetButton("Jump") && isJumping) //This is done outside of FixedUpdate cause it wouldn't work, will come back to it later
        {
            //Add more force to the jump over a given time
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

        //Check for jump button release
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
}
