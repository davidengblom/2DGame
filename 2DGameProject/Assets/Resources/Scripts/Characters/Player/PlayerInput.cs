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
        
        moveInput.x = Input.GetAxisRaw("Horizontal"); //Movement Input

        #region Jumping
        grounded = Physics2D.OverlapCircle(player.groundCheck.position, player.groundCheckRadius, player.groundLayer); //Check If On Ground

        if(grounded && Input.GetButtonDown("Jump")) //Jump Input
        {
            player.movement.doJump = true;
        }

        if (player.movement.jumping && Input.GetButton("Jump")) //Hold To Jump Higher Input
        {
            player.movement.holdJump = true;
        }

        if (Input.GetButtonUp("Jump")) //Let Go Of The Jump Key
        {
            player.movement.jumping = false;
            player.movement.holdJump = false;
        }
        #endregion

        #region Player Direction
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position); //Player's Position On The Screen

        if (Input.mousePosition.x < playerScreenPosition.x) //Mouse Position Relative To Player (Left or Right)
        {
            if(!player.anim.facingLeft)
            {
                player.anim.FaceLeft();
            }
        }
        else
        {
            if(!player.anim.facingRight)
            {
                player.anim.FaceRight();
            }
        }
        #endregion

        #region Weapons
        if (Input.GetKeyDown(KeyCode.Alpha1) && player.currentWeapon != Weapon.Fists) //Press "1" To Swap To Fists
        {
            player.currentWeapon = Weapon.Fists;
            player.anim.SwapFists();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && player.currentWeapon != Weapon.Gun) //Press "2" To Swap To Gun
        {
            player.currentWeapon = Weapon.Gun;
            player.anim.SwapGun();
        }

        if(Time.time > player.nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1") && player.currentWeapon == Weapon.Fists)
            {
                player.combat.Punch();
            }
        }
        #endregion
    }
}
