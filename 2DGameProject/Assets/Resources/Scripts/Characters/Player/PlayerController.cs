using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon { Fists, Bat, Gun }

public class PlayerController : MonoBehaviour
{
    //Audio clips
    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip walkSound;

    //Current Weapon
    [Header("Weapon")]
    public Weapon currentWeapon; //Fix this shit

    //Public variables
    [Header("Movement Variables")]
    public float moveSpeed = 5f;
    public float stepInterval = 0.1f;
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

        currentWeapon = Weapon.Fists;

        StartCoroutine(PlayWalkSound()); //As long as the character lives, it checks if they are moving, playing the sound if they are
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        //Jumping
        if(doJump)
        {
            audioSource.PlayOneShot(jumpSound); //Play the jump sound

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
        
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentWeapon != Weapon.Fists)
        {
            currentWeapon = Weapon.Fists;
            animator.SetTrigger("Fists");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && currentWeapon != Weapon.Gun)
        {
            currentWeapon = Weapon.Gun;
            animator.SetTrigger("Gun");
        }
    }

    private IEnumerator PlayWalkSound()
    {
        while(true)
        {
            //If the player is on the ground and moving left or right
            if(isGrounded && moveInput.x >= 1 || isGrounded && moveInput.x <= -1)
            {
                audioSource.PlayOneShot(walkSound);
                yield return new WaitForSeconds(stepInterval);
            }
            else
            {
                yield return 0;
            }
            

        }
    }
}
