using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour
{

    [SerializeField] private float moveForce = 365f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private Transform groundCheck;

    private bool isFacingRight = true;
    private bool isJump = true;


    private bool isGrounded = false;
    private Animator anim;
    private Rigidbody2D rb2d; 

	// Use this for initialization
	void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJump = true;
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !isFacingRight)
            Flip();
        else if (h < 0 && isFacingRight)
            Flip();

        if(isJump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            isJump = false;
        }

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
