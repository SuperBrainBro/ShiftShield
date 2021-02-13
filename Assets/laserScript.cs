using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class laserScript : MonoBehaviour
{

	public float moveSpeed = 7f;
	public float realSpeed;

	public GameObject destroyEffect;

	private DontDestroyScript dontDestroy;

	Rigidbody2D rb;

	GameObject target;
	Vector2 moveDirection;

	public bool facePlayer;

	public string loseScreen;
	void Start()
	{
		dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("Player");
		moveDirection = (target.transform.position - transform.position).normalized * realSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		if (facePlayer)
		{
			transform.right = target.transform.position - transform.position;
		}
		Destroy(gameObject, 3f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			if (col.gameObject.GetComponent<FinalPlayer>() == null)
			{
				dontDestroy.Die();
				Debug.Log("Killed Player");
				dontDestroy.BossMusic.Stop();
				SceneManager.LoadScene(loseScreen);
			}
			
		}
		if (col.gameObject.layer.Equals("Ground"))
		{
			Debug.Log("Hit Ground!");
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
