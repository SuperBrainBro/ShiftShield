using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour
{
    //Private Variables
    private Collider2D col;

    public string loseScreen;
    private DontDestroyScript dontDestroy;
    private void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();     
        col = GetComponent<Collider2D>();

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dontDestroy.Die();
            SceneManager.LoadScene(loseScreen);
            Debug.Log("Killed Player");
            dontDestroy.BossMusic.Stop();
        }
    }
}
