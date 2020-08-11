using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    //Main Player Script
    internal PlayerController player;

    //Local Variables
    internal bool playJumpSound;

    void Start()
    {
        //Assign Components
        player = GetComponent<PlayerController>();

        //While the character is alive, play the walking sound if he moves
        StartCoroutine(PlayWalkSound());
    }

    void FixedUpdate()
    {
        //If jump input is pressed, play the jump sound
        if(playJumpSound)
        {
            player.audioSource.PlayOneShot(player.jumpSound);
            playJumpSound = false;
        }
    }

    private IEnumerator PlayWalkSound() //Refer to the start function for information
    {
        while(true)
        {
            if(player.input.grounded && player.input.moveInput.x >= 1 || player.input.grounded && player.input.moveInput.x <= -1)
            {
                player.audioSource.PlayOneShot(player.walkSound);
                yield return new WaitForSeconds(player.stepInterval);
            }
            else
            {
                yield return 0;
            }
        }
    }
}
