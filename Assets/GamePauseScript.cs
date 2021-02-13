using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseScript : MonoBehaviour
{
    private DontDestroyScript dontDestroy;
    private void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
        if (!dontDestroy.BossMusic.isPlaying)
        {
            dontDestroy.BossStart();
        }
    }
}
