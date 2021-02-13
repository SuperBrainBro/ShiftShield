using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusicScript : MonoBehaviour
{
    private DontDestroyScript dontDestroy;
    private void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
        dontDestroy.MenuMusic();
        Destroy(this.gameObject);
    }
}
