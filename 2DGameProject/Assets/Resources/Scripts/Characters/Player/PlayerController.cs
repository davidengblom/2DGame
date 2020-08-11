using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Player Components
    internal PlayerInput input;
    internal PlayerMovement movement;
    internal PlayerSound sound;

    [Header("External Components")]
    [SerializeField] internal Animator animator;
    [SerializeField] internal Transform groundCheck;

    [Header("Player Properties")]
    [SerializeField] internal float moveSpeed = 5f;
    [SerializeField] internal float jumpHeight = 7f;
    [SerializeField] internal float jumpTime = 0.2f;
    
    //Local Variables
    internal float groundCheckRadius = 0.3f;
    internal LayerMask groundLayer;

    //Local Components
    internal Rigidbody2D rb;
    internal AudioSource audioSource;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        sound = GetComponent<PlayerSound>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        groundLayer = LayerMask.GetMask("Ground");
    }
}
