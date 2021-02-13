using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlatformerController : MonoBehaviour
{
	//Private Variables

	private float initForce;
	private float groundedVal;
	private float jumpForce = 125f;
	private float maxHieght;
	private bool wasCrouching = false;
	private Rigidbody2D rb;
	private bool facingRight = true;
	private Vector3 moveVelocity = Vector3.zero;

	//Public Variables
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public Transform ceilingCheck;
	public Collider2D crouchDisableCollider;
	public Animator anim;
	[HideInInspector] public bool grounded;

	//Contant Variables
	const float groundedRadius = 3.1f;
	const float ceilingRadius = 1f;

	private DontDestroyScript dontDestroy;
	private void Start()
	{
		dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
		rb = GetComponent<Rigidbody2D>();

		initForce = jumpForce;
	}
	private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		groundedVal -= 0.25f;

		if (groundedVal < 0)
		{
			grounded = false;
		}
		else
		{
			grounded = true;
		}

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				groundedVal = 2;
				jumpForce = initForce;
				maxHieght = initForce;
			}
		}
	}
	public void Move(float move, bool crouch, bool jump)
	{
		if (!crouch)
		{
			if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
			{
				crouch = true;
			} 
		}
		if (crouch)
		{
			anim.SetBool("Crouch", true);
			if (!wasCrouching)
			{
				wasCrouching = true;
			}
			move *= .5f;
			if (crouchDisableCollider != null)
			{
				crouchDisableCollider.enabled = false;
			}
		}
		else
		{
			anim.SetBool("Crouch", false);
			if (crouchDisableCollider != null)
			{
				crouchDisableCollider.enabled = true;
			}
			if (wasCrouching)
			{
				wasCrouching = false;
			}
		}

		Vector3 targetVelocity = new Vector2(transform.right.x * move * 10f, rb.velocity.y);
		rb.velocity = targetVelocity;

		if (move > 0 && !facingRight)
		{
			Flip();
		}
		else if (move < 0 && facingRight)
		{
			Flip();
		}

		if (grounded && jump)
		{
			groundedVal = 0;
			dontDestroy.Jump();
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -500, maxHieght));
	}
	private void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
