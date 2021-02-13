using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldArrowScript : MonoBehaviour
{
    private DontDestroyScript dontDestroy;
    private void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dontDestroy.Gold();
            collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x +.25f, collision.gameObject.transform.localScale.y + .25f, collision.gameObject.transform.localScale.z);
        }
    }
}
