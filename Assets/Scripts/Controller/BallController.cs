using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float maxSpeed = 10f; 
	
	public int posY = 600;
	public int posX = 400;

	public bool isGrounded = true;
	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	public float groundRadius = 0.1f;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;

	public bool isWallJump = false;
	public bool sideToJump = false;
	public bool timeJump = false;

	//---------------------------------------------------------------------------
	private void Start()
	{
		groundRadius = gameObject.GetComponent<Renderer>().bounds.size.y / 2;
	}
	//---------------------------------------------------------------------------
	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 

		float move = Input.GetAxis ("Horizontal");

		if (!isWallJump) 
		{
			if (!timeJump)
			{
				if (move != 0)
					GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			} else 
				{					    
					GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
				}
		} else 
			{
				if ( (move < 0 && sideToJump) || (move > 0 && !sideToJump) )
				{
					endWall();
				}
				
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
			}

	}
	//---------------------------------------------------------------------------
	private void Update()
	{
		if ( !isWallJump && isGrounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, posY));	

			isGrounded = false;
		}	

		if (isWallJump && isGrounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			float powerJump = posX;

			if (sideToJump)
			{
				powerJump = -powerJump;
			}

			GetComponent<Rigidbody2D>().AddForce(new Vector2(powerJump, posY));

			isWallJump = false;

			isGrounded = false;
		}
	}
	//---------------------------------------------------------------------------
	public void setWallJump (bool isWall, bool orientWall )
	{
		isWallJump = isWall;
		sideToJump = orientWall;
		timeJump = true;
	}
	//---------------------------------------------------------------------------
	public void endWall ( )
	{
		isWallJump = false;
		isGrounded = false;	
	}
	//---------------------------------------------------------------------------
	public void notTimeJump ()
	{
		timeJump = false;
	}
}
