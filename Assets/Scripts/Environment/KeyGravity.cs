using UnityEngine;
using System.Collections;

public class KeyGravity : MonoBehaviour {

    public LayerMask whatIsGround; // A mask determining what is ground to the character

    private Transform groundCheck; 
    public float groundedRadius = .2f;
    private bool grounded = false;

    Rigidbody2D gravity;
    BoxCollider2D collider;


    void Start () {
        groundCheck = transform.Find("GroundCheck");
        gravity = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        if (grounded != gravity.isKinematic)
        {
            gravity.isKinematic = grounded;
            collider.isTrigger = grounded;
        }
    }
}
