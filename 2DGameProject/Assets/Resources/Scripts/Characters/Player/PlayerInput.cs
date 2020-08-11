using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Main Player Script
    private PlayerController player;

    //Local Variables
    internal Vector2 moveInput;
    internal bool grounded;

    void Start()
    {
        //Assign Components
        player = GetComponent<PlayerController>(); 
    }

    void Update()
    {
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position); //Player's Position On The Screen
        moveInput.x = Input.GetAxisRaw("Horizontal"); //Movement Input
        grounded = Physics2D.OverlapCircle(player.groundCheck.position, player.groundCheckRadius, player.groundLayer); //Check If On Ground

        if(grounded && Input.GetButtonDown("Jump")) //Jump Input
        {
            player.movement.doJump = true;
        }

        if(player.movement.jumping && Input.GetButton("Jump")) //Hold To Jump Higher Input
        {
            player.movement.holdJump = true;
        }

        if(Input.GetButtonUp("Jump")) //Let Go Of The Jump Key
        {
            player.movement.jumping = false;
            player.movement.holdJump = false;
        }

        if(Input.mousePosition.x < playerScreenPosition.x) //Mouse Position Relative To Player (Left or Right)
        {
            player.anim.FaceLeft();
        }
        else
        {
            player.anim.FaceRight();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && player.currentWeapon != Weapon.Fists) //Press "1" To Swap To Fists
        {
            player.currentWeapon = Weapon.Fists;
            player.anim.SwapFists();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && player.currentWeapon != Weapon.Gun) //Press "2" To Swap To Gun
        {
            player.currentWeapon = Weapon.Gun;
            player.anim.SwapGun();
        }
    }
}
