using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private PlayerController player; //Main Player Script

    void Start()
    {
        player = GetComponent<PlayerController>();

        //While the character is alive, play the walking sound if he moves
        StartCoroutine(PlayWalkSound());
    }

    private IEnumerator PlayWalkSound() //Refer to the start function for information
    {
        while(true)
        {
            //If the player is on the ground and moving left or right
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

    internal void PlayJumpSound()
    {
        player.audioSource.PlayOneShot(player.jumpSound);
    }

    internal void PlayPunchSound()
    {
        player.audioSource.PlayOneShot(player.punchSound);
    }
}
