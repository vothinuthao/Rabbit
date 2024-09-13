using System;
using System.Collections;
using System.Collections.Generic;
using Code.Interface;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration;
    public float groundSpeed;
    public float jumpSpeed;
    [Range(0f, 1f)] public float groundDecay;
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public bool grounded;
    private float xInput;
    private float yJump = 2f;
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleJump();
    }
    private void FixedUpdate()
    {
        CheckGround();
        MoveWithInput();
        ApplyFriction();
    }
    void GetInput() {
         xInput = Input.GetAxis("Horizontal");
    }

    public void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newspeed = Mathf.Clamp(body.velocity.x + increment,-groundSpeed,groundSpeed);
            body.velocity = new Vector2(newspeed, body.velocity.y);
            animator.SetBool("isRunning", true);
            FaceInput();
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    void FaceInput()
    {
        float direction = 0.5f*Mathf.Sign(xInput);
        transform.localScale = new Vector3(-direction, 0.5f, 0.5f);
    }
    public void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, yJump * jumpSpeed);
            animator.SetTrigger("jumpTrigger");
            // thay đổi vị trí hiện tại của player theo 2D x và Y 
            // cách để kiểm tra lỗi 
           //   Debug.Log("check bug here: " + yJump * jumpSpeed); // => cách để em có thể check lỗi nãy a check thấy chỉ số nó bằng 0 nên k thể nhảy đc 
        }
        
    }
    void CheckGround()
    {
        // ReSharper disable once Unity.PreferNonAllocApi
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && body.velocity.y<= 0)
        {
            body.velocity *= groundDecay;
        }
    }
   
        
    
    
    
}

   
