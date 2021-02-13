using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float waitTime;
    private PlatformEffector2D effector;
    private bool cEnabled = false;
    void Start()
    {
        if (GetComponent<PlatformEffector2D>() != null)
        {
            effector = GetComponent<PlatformEffector2D>();
            cEnabled = true;
        }
        waitTime = 0.01f;
    }

    void Update()
    {
        if (cEnabled)
        {
            if (Input.GetButtonUp("Down"))
            {
                waitTime = 0.01f;
                effector.rotationalOffset = 0f;
            }

            if (Input.GetButton("Down"))
            {
                if (waitTime <= 0)
                {
                    effector.rotationalOffset = 180f;
                    waitTime = 0.1f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }

            if (Input.GetButton("Jump"))
            {
                effector.rotationalOffset = 0f;
            }
        }
    }
}
