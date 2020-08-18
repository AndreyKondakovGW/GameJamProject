using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Character : Unit
{
  
    [SerializeField]
    public float speed = 3.5F;
    [SerializeField]
    private float jumpForce = 17.0F;
    
    private bool IsGrounded = false;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public AudioSource StepSoud;
    public Characters CharacterName;
    public GameObject LevelControler;

    private Animator animator;
    private Rigidbody2D rigitbody;
    private SpriteRenderer sprite;

    private void Awake()
    {
        
        rigitbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

       
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Update()
    {
        

        if (Input.GetButton("Horizontal")) Run();
        else State = CharState.Stay;
        if (Input.GetButtonDown("Jump")) Jump();
        if (Input.GetButtonDown("Horizontal")) StepSoud.Play();
        if (Input.GetButtonUp("Horizontal")) StepSoud.Stop();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x > 0.0F;
   
        State = CharState.Move;
    }

    private void Jump()
    {
        rigitbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

   
    private void CheckGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1F);

        IsGrounded = colliders.Length > 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();
    }
}
 
public enum CharState
{
    Stay,
    Move
}