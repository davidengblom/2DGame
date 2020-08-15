using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerController player; //Main Player Script

    internal LayerMask enemies; //Enemy Layer

    void Start()
    {
        player = GetComponent<PlayerController>();

        player.currentWeapon = Weapon.Fists; //Set starter Weapon
        enemies = LayerMask.GetMask("Enemy"); 
    }

    internal void Punch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.attackPoint.position, player.meleeRange, enemies);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(player.fistsDamage);
        }

        player.anim.PunchAnimation(); //Play punch animation
        player.nextAttackTime = Time.time + 1f / player.attackRate; //Start the attackRate timer
        player.sound.PlayPunchSound(); //Play punch sound
    }

    private void OnDrawGizmosSelected()
    {
        if(player.attackPoint = null)
        {
            return;
        }
        Gizmos.DrawWireSphere(player.attackPoint.position, player.meleeRange);
    } //Draws a line for the meleeRange
}
