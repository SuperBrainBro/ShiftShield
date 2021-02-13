using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introTimer : MonoBehaviour
{
    public float timeEach;
    public string nextLevel;
    private float timeLeft;
    private GameObject cam;
    public bool cameraZoom = true;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        timeLeft = timeEach + Time.time;
    }

    void Update()
    {
        if (cameraZoom)
        {
            if (cam.GetComponent<Animator>() != null)
            {

                if (Time.time + 1 > timeLeft)
                {
                    GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

                    foreach (GameObject bullet in bullets)
                    {
                        bullet.SetActive(false);
                    }
                    cam.GetComponent<Animator>().SetTrigger("Zoom");
                }
            }
        }

        if (Time.time > timeLeft)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
