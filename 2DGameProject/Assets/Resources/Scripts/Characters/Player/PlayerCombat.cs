using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Main Player Script
    internal PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    internal void Punch()
    {
        player.anim.PunchAnimation(); //Play punch animation
        player.nextAttackTime = Time.time + 1f / player.attackRate; //Start the attackRate timer
        player.sound.PlayPunchSound(); //Play punch sound
    }
}
