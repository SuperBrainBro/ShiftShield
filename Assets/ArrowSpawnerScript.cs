using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawnerScript : MonoBehaviour
{
    //Private Variables
    private float timeLeft;

    //Public Variables
    public float spawnRate;
    public GameObject arrow;
    public float speed;
    void Start()
    {
        timeLeft = Time.time;
    }
    void Update()
    {
        if (timeLeft < Time.time)
        {
            timeLeft += spawnRate;
            Vector3 spawnPoint = new Vector3();
            int vertical = 0;
            vertical = Random.Range(0, 4);
            if (vertical == 0)
            {
                spawnPoint.x = Random.Range(170, 190);
            } else if (vertical == 1)
            {
                spawnPoint.y = Random.Range(170, 190);
            }
            else if (vertical == 2)
            {
                spawnPoint.x = Random.Range(-170, -190);
            }
            else if (vertical == 3)
            {
                spawnPoint.y = Random.Range(-170, -190);
            }
            GameObject nextArrow = arrow;
            nextArrow.GetComponent<ArrowScript>().speed = speed;
            nextArrow.GetComponent<ArrowScript>().directionSent = vertical;

            Instantiate(nextArrow, spawnPoint, Quaternion.identity);

            Debug.Log("Spawned Object At Position: " + spawnPoint);
            if (spawnRate > .7)
            {
                spawnRate -= 0.025f;
            }
            if (speed < 110)
            {
                speed += 1.25f;
            }
        }
        timeLeft -= Time.deltaTime;
    }
}
