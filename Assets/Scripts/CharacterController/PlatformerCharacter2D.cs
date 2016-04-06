using UnityEngine;

namespace UnitySampleAssets._2D
{

    public class PlatformerCharacter2D : MonoBehaviour
    {
        private bool facingRight = true; // For determining which way the player is currently facing.

        [SerializeField]
        private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
        [SerializeField]
        private float jumpForce = 400f; // Amount of force added when the player jumps.	

        [Range(0, 1)]
        [SerializeField]
        private float crouchSpeed = .36f;
        // Amount of maxSpeed applied to crouching movement. 1 = 100%

        [SerializeField]
        private bool airControl = false; // Whether or not a player can steer while jumping;
        [SerializeField]
        private LayerMask whatIsGround; // A mask determining what is ground to the character

        private Transform groundCheck; // A position marking where to check if the player is grounded.
        private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool grounded = false; // Whether or not the player is grounded.
        private Transform ceilingCheck; // A position marking where to check for ceilings
        private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator anim; // Reference to the player's animator component.


        private void Awake()
        {
            // Setting up references.
            groundCheck = transform.Find("GroundCheck");
            ceilingCheck = transform.Find("CeilingCheck");
            anim = transform.FindChild("Img").GetComponent<Animator>();
        }


        private void FixedUpdate()
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

            anim.SetBool("Ground", grounded);

            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        }


        public void Move(Vector2 move, bool crouch, bool jump)
        {
            if (!crouch && anim.GetBool("Crouch"))
            {
                if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
                    crouch = true;
            }

            anim.SetBool("Crouch", crouch);

            if (grounded || airControl)
            {
                move = (crouch ? move * crouchSpeed : move);

                anim.SetFloat("Speed", Mathf.Abs(move.x));
                var spedX = move.x * maxSpeed;

                if (!grounded && airControl) spedX /= 1.5f;

                GetComponent<Rigidbody2D>().velocity = new Vector2(spedX, GetComponent<Rigidbody2D>().velocity.y);

                if (move.x > 0 && !facingRight)
                    Flip();
                else if (move.x < 0 && facingRight)
                    Flip();
            }

            if (grounded && jump && anim.GetBool("Ground"))
            {
                grounded = false;
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            }
        }


        private void Flip()
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}