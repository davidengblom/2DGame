using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal PlayerController player;

    internal bool doJump;
    internal bool holdJump;
    internal bool jumping;
    internal float jumpTimeCounter;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        player.rb.velocity = new Vector2(player.input.moveInput.x * player.moveSpeed, player.rb.velocity.y);

        if(doJump)
        {
            jumping = true;
            jumpTimeCounter = player.jumpTime;
            player.rb.velocity = Vector2.up * player.jumpHeight;
            doJump = false;
        }

       
    }

    void Update()
    {
        if (holdJump)
        {
            if (jumpTimeCounter > 0)
            {
                player.rb.velocity = Vector2.up * player.jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jumping = false;
                holdJump = false;
            }
        }
    }
}
