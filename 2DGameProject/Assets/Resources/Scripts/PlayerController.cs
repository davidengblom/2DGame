using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float groundCheckRadius = 0.3f;

    //Private Variables
    private Vector2 moveInput;
    private bool isGrounded;
    private bool jump;
    public LayerMask groundLayer;
    
    //Components
    private Rigidbody2D rb;
    private Animator animator;
    private Transform feet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        feet = GameObject.Find("GroundCheck").transform;
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        if(jump)
        {
            rb.velocity = Vector2.up * jumpHeight;
            jump = false;
        }

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);
        moveInput.x = Input.GetAxisRaw("Horizontal"); 

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
}
