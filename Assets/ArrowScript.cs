using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowScript : MonoBehaviour
{
    //Private Variables
    private Rigidbody2D rb;
    private PlayerScript player;

    //Public Variables
    public float speed;
    public int directionSent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        transform.up = player.transform.position - transform.position;
        rb.velocity = (player.transform.position - transform.position).normalized * speed;  
    }
}
