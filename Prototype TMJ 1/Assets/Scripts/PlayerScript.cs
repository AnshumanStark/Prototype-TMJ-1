using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private float speedMultiplier = 8;
    private float jumpForce = 15;
    private bool jump;
    private bool isGrounded;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        horizontalInput = Input.GetAxis("Horizontal");

        //face forward
        transform.forward = new Vector3(-horizontalInput, 0, -(Mathf.Abs(horizontalInput) - 1));

        //move animation
        anim.SetFloat("Speed", horizontalInput);

        //Set Animator Is Grounded
        anim.SetBool("IsGrounded", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //move
        rb.velocity = new Vector3(horizontalInput * speedMultiplier, rb.velocity.y, 0);

        //IsGrounded
        isGrounded = Physics.OverlapBox(rb.position, Vector3.one * 0.3f).Length > 2;

        //Set paremeter for JumpFall Blend Animation
        anim.SetFloat("VerticalSpeed", rb.velocity.y);

        //Jump
        if (jump && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jump = false;
        }

        rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(-20f, rb.velocity.y), rb.velocity.z);
    }
}
