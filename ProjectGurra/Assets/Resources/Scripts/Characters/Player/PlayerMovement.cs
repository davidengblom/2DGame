﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController player; //Main Player Script

    //Local Variables
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
        //Move The Player
        player.rb.velocity = new Vector2(player.input.moveInput.x * player.moveSpeed, player.rb.velocity.y);

        //Jump
        if(doJump)
        {
            player.sound.PlayJumpSound();
            jumping = true;
            jumpTimeCounter = player.jumpTime;
            player.rb.velocity = Vector2.up * player.jumpHeight;
            doJump = false;
        }
    }

    void Update()
    {
        //Hold To Jump Higher
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
            }
        }
    }
}
