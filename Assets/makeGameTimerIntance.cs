using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeGameTimerIntance : MonoBehaviour
{
    public GameObject timer;
    void Start()
    {
        Instantiate(timer, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
