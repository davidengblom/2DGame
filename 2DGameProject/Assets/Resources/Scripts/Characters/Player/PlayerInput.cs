using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    internal PlayerController player;

    internal Vector2 moveInput;
    internal bool grounded;

    void Start()
    {
        player = GetComponent<PlayerController>(); 
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        grounded = Physics2D.OverlapCircle(player.groundCheck.position, player.groundCheckRadius, player.groundLayer);

        if(grounded && Input.GetButtonDown("Jump"))
        {
            player.movement.doJump = true;
        }

        if(player.movement.jumping && Input.GetButton("Jump"))
        {
            player.movement.holdJump = true;
        }
        else
        {
            player.movement.holdJump = false;
        }
    }
}
