using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGroundSpawner : MonoBehaviour
{
    //Private Variables
    private float timeLeft;
    private float prevSpawnPoint = 100;
    private GameObject cam;
    public float spawnRate;
    private float prevY;
    //Public Variables
    public float initSpawnRate;
    public GameObject ground;
    public float xOffset;
    void Start()
    {
        prevSpawnPoint = xOffset;
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        //spawnRate = initSpawnRate - cam.GetComponent<PlatformerCamera>().speed * 10;
        spawnRate = initSpawnRate - cam.GetComponent<PlatformerCamera>().speed * 2;
        
        timeLeft = Time.time;
        timeLeft += spawnRate;
    }
    void Update()
    {
        if (timeLeft < Time.time)
        {
            //Update Time Left
            timeLeft += spawnRate;

            if (spawnRate > 2.5)
            {
                spawnRate = spawnRate - cam.GetComponent<PlatformerCamera>().speed * 2;
            }

            //Spawn First Batch
            Vector3 spawnPoint = new Vector3();
            spawnPoint.y = Random.Range(-40, 20);
            spawnPoint.y = (int)spawnPoint.y;
            spawnPoint.x = prevSpawnPoint;
            possibleJump(spawnPoint.y, spawnPoint);
            Debug.Log("Spawned First Object At Y Position: " + spawnPoint.y);

            //Set Previous Y Val
            prevY = spawnPoint.y;

            //Spawn Second Batch
            spawnPoint.y -= 50;
            if (spawnPoint.y > -40)
            {
                Debug.Log("Spawned Second Object At Y Position: " + spawnPoint.y);
                possibleJump(spawnPoint.y, spawnPoint);
            }
            else
            {
                spawnPoint.y += 10;
                if (spawnPoint.y > -40)
                {
                    Debug.Log("Spawned Second Object At Y Position: " + spawnPoint.y);
                    possibleJump(spawnPoint.y, spawnPoint);
                }
                else
                {
                    spawnPoint.y += 10;
                    if (spawnPoint.y > -40)
                    {
                        Debug.Log("Spawned Second Object At Y Position: " + spawnPoint.y);
                        possibleJump(spawnPoint.y, spawnPoint);
                    }
                    else
                    {
                        spawnPoint.y += 10;
                        if (spawnPoint.y > -40)
                        {
                            Debug.Log("Spawned Second Object At Y Position: " + spawnPoint.y);
                            possibleJump(spawnPoint.y, spawnPoint);
                        }
                    }
                }
            }

            //Set The PrevSpawnPoint To The Recent Spawn Point
            prevSpawnPoint += 50;
        }
        timeLeft -= Time.deltaTime;
    }
    public void possibleJump(float yVal, Vector3 spawnPointXY)
    {
        if (Mathf.Abs(prevY - yVal) > 5)
        {
            Instantiate(ground, spawnPointXY, Quaternion.identity);
        }
        else
        {
            spawnPointXY.y = prevY + (-(Mathf.Sign(prevY)) * 10);
            Instantiate(ground, spawnPointXY, Quaternion.identity);
        }
    }
}
