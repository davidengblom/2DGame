using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController player; //Main Player Script

    internal bool facingLeft;
    internal bool facingRight;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        //Set animation parametres
        player.animator.SetFloat("Horizontal", player.input.moveInput.x);
        player.animator.SetFloat("Speed", player.input.moveInput.sqrMagnitude);
        player.animator.SetBool("Grounded", player.input.grounded);
    }

    #region Weapons
    internal void PunchAnimation()
    {
        player.animator.SetTrigger("Punch");
    }

    internal void SwapFists() //Swap to Fists
    {
        player.animator.SetTrigger("Fists");
    }

    internal void SwapGun() //Swap to Gun
    {
        player.animator.SetTrigger("Gun");
    }
    #endregion

    #region Player Direction
    internal void FaceRight() //Flip the Character Right
    {
        player.animator.SetBool("FacingRight", true);
        player.animator.SetBool("FacingLeft", false);

        facingRight = true;
        facingLeft = false;

        player.attackPoint.position = new Vector3(player.transform.position.x + 0.25f, player.transform.position.y, player.transform.position.z);
        player.attackPoint.rotation = Quaternion.Euler(0, 0, 0);
        
    }

    internal void FaceLeft() //Flip the Character Left
    {
        player.animator.SetBool("FacingLeft", true);
        player.animator.SetBool("FacingRight", false);

        facingLeft = true;
        facingRight = false;

        player.attackPoint.position = new Vector3(player.transform.position.x + -0.25f, player.transform.position.y, player.transform.position.z);
        player.attackPoint.rotation = Quaternion.Euler(0, 180, 0);
    }
    #endregion
}
