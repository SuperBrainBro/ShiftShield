using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLaser : MonoBehaviour
{

	public float moveSpeed = 140f;
	public float realSpeed;

	private DontDestroyScript dontDestroy;

	Rigidbody2D rb;

	GameObject target;
	Vector2 moveDirection;
	void Start()
	{
		dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("Corruption");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		transform.up = target.transform.position - transform.position;
		Destroy(gameObject, 12f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Corruption"))
		{
			dontDestroy.Gold();
			col.gameObject.GetComponent<Animator>().SetTrigger("Hit");
			Destroy(this.gameObject);
		}
	}

}
