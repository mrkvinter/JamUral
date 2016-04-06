using System;
using UnityEngine;
using System.Collections;

public class PlayerMonsterMove2D : MonoBehaviour {

    private bool facingRight = true; // For determining which way the player is currently facing.

    [SerializeField]
    private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
    [SerializeField]
    private float jumpForce = 400f; // Amount of force added when the player jumps.	

    [Range(0, 1)]
    [SerializeField]
    private float crouchSpeed = .36f;
    // Amount of maxSpeed applied to crouching movement. 1 = 100%

    //[SerializeField]
    //private LayerMask whatIsGround; // A mask determining what is ground to the character

    //private Transform groundCheck; // A position marking where to check if the player is grounded.
    //private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    //private bool grounded = false; // Whether or not the player is grounded.
    private Transform ceilingCheck; // A position marking where to check for ceilings
    private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator anim; // Reference to the player's animator component.

    public Transform Player;

    public float MaxLen;


    private void Awake()
    {
        // Setting up references.
        //anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

        //anim.SetBool("Ground", grounded);

        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }


    public void Move(Vector2 move, bool crouch, bool jump)
    {
       // if (!crouch /*&& anim.GetBool("Crouch")*/)
        //{
           // if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
            //    crouch = true;
        //}

        //anim.SetBool("Crouch", crouch);
        Vector2 vLen = transform.position - Player.position;
        var len = (MaxLen - vLen.magnitude)/MaxLen;
        if (len >= 0.4f) len = 1;
        else if(len > 0.1f) len *= 2.1f;
        else len = -0.1f;
        if ((int)Mathf.Sign(vLen.x) == (int)-Mathf.Sign(move.x) && Math.Abs(move.x) > 0.01 && 
             (int)Mathf.Sign(vLen.y) == (int)-Mathf.Sign(move.y) && Math.Abs(move.y) > 0.01)
            len = 1;

        //anim.SetFloat("Speed", Mathf.Abs(move));
        var sped = move*maxSpeed * len;

        
        GetComponent<Rigidbody2D>().velocity = sped;

        if (!(len > -0.01f)) return;
        if (sped.x > 0 && !facingRight)
            Flip();
        else if (sped.x < 0 && facingRight)
            Flip();
    }


    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
