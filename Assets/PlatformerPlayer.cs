using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
	//Private Variables
	private float horizontalMove = 0f;
	private bool jump = false;
	private bool crouch = false;
	private Rigidbody2D rb;
	private float runSpeed = 280f;
	private float dashSpeed = 22000f;
	private float dashTimeLeft = 0f;
	private float startDashTimeLeft = 0.5f;

	//Public Variables
	public PlatformerController controller;
	public Animator anim;
	public GameObject dashEffect;


	private DontDestroyScript dontDestroy;
	private void Start()
	{
		dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
		dashTimeLeft = startDashTimeLeft;
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			if (jump == false)
			{
				StartCoroutine(waitJump(.15f));
				jump = true;

			}
		}
		if (Input.GetButtonDown("Crouch"))
		{
			anim.SetBool("Crouch", true);
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			//anim.SetBool("Crouch", false);
			crouch = false;
		}

		if (Input.GetButtonDown("Dash"))
		{
			if (dashTimeLeft < 0)
			{
				dashTimeLeft = startDashTimeLeft;
				if (gameObject.transform.localScale.x == -1)
				{
					rb.AddForce(Vector2.left * dashSpeed);
				}
				else if (gameObject.transform.localScale.x == 1)
				{
					rb.AddForce(Vector2.right * dashSpeed);
				}
				dontDestroy.Dash();
				Instantiate(dashEffect, transform.position, Quaternion.identity);
			}
		}		
		dashTimeLeft -= Time.deltaTime;
	}
	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	}
	private IEnumerator waitJump(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		jump = false;
	}
}