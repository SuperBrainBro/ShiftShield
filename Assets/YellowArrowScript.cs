using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YellowArrowScript : MonoBehaviour
{
    //Private Variables
    private Rigidbody2D rb;
    private PlayerScript player;
    private float distanceBetween;
    private bool canDo = true;
    //Public Variables
    public float speed;
    public int directionSent;
    public GameObject explosion;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        transform.up = player.transform.position - transform.position;
        rb.velocity = (player.transform.position - transform.position).normalized * speed;
    }

    private void Update()
    {
        distanceBetween = Vector3.Distance(transform.position, player.transform.position);
        if (canDo)
        {
            if (distanceBetween < 20)
            {
                canDo = false;

                Instantiate(explosion, transform.position, Quaternion.identity);

                transform.position = new Vector3(transform.position.x * -1, transform.position.y * -1, transform.position.z);

                directionSent = setDirection(directionSent);

                transform.up = player.transform.position - transform.position;
                rb.velocity = (player.transform.position - transform.position).normalized * speed;
            }
        }       
    }

    public int setDirection(int directionWasSent)
    {
        switch (directionWasSent)
        {
            case 0:
                return 2;
            case 1:
                return 3;
            case 2:
                return 0;
            case 3:
                return 1;
        }
        return directionWasSent;
    }
}
