using UnityEngine;

internal enum Weapon { Fists, Bat, Gun }

public class PlayerController : MonoBehaviour
{
    //Player Components
    internal PlayerInput input;
    internal PlayerMovement movement;
    internal PlayerSound sound;
    internal PlayerAnimation anim;
    internal PlayerCombat combat;

    [Header("Audio Files")]
    [SerializeField] internal AudioClip walkSound;
    [SerializeField] internal AudioClip jumpSound;
    [SerializeField] internal AudioClip punchSound;

    [Header("External Components")]
    [SerializeField] internal Animator animator;
    [SerializeField] internal Transform groundCheck;
    [SerializeField] internal Transform attackPoint;

    [Header("Player Properties")]
    [SerializeField] internal float moveSpeed = 5f;
    [SerializeField] internal float stepInterval = 0.1f;
    [SerializeField] internal float jumpHeight = 7f;
    [SerializeField] internal float jumpTime = 0.2f;
    [SerializeField] internal float attackRate = 2f;
    [SerializeField] internal float meleeRange = 0.5f;

    [Header("Weapon Properties")]
    [SerializeField] internal int fistsDamage = 10;
    [SerializeField] internal int batDamage = 20;
    [SerializeField] internal int gunDamage = 40;

    //Local Variables
    internal Weapon currentWeapon;
    internal float groundCheckRadius = 0.3f;
    internal float nextAttackTime = 0f;
    internal LayerMask groundLayer;

    //Local Components
    internal Rigidbody2D rb;
    internal AudioSource audioSource;

    void Start()
    {
        //Assign Components & Variables
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        sound = GetComponent<PlayerSound>();
        anim = GetComponent<PlayerAnimation>();
        combat = GetComponent<PlayerCombat>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
}
