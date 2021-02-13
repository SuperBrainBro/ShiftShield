using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class flagScript : MonoBehaviour
{
    public string nextScene;
    public bool disableMusicOnLoad;
    private DontDestroyScript dontDestroy;
    private void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dontDestroy.LevelFinish();
        if (disableMusicOnLoad)
        {
            dontDestroy.MenuMenu.Stop();
        }
        SceneManager.LoadScene(nextScene);
    }
}
