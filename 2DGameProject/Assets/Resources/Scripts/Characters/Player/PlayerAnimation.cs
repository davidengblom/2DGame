using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Main Player Script
    private PlayerController player;

    void Start()
    {
        //Assign Components
        player = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        //Set animation parametres
        player.animator.SetFloat("Horizontal", player.input.moveInput.x);
        player.animator.SetFloat("Speed", player.input.moveInput.sqrMagnitude);
        player.animator.SetBool("Grounded", player.input.grounded);
    }

    internal void SwapFists() //Swap to Fists
    {
        player.animator.SetTrigger("Fists");
    }

    internal void SwapGun() //Swap to Gun
    {
        player.animator.SetTrigger("Gun");
    }

    internal void FaceRight() //Flip the Character Right
    {
        player.animator.SetBool("FacingRight", true);
        player.animator.SetBool("FacingLeft", false);
    }

    internal void FaceLeft() //Flip the Character Left
    {
        player.animator.SetBool("FacingLeft", true);
        player.animator.SetBool("FacingRight", false);
    }
}
