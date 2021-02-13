using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public AudioSource BossMusic;
    public AudioSource JumpFX;
    public AudioSource LevelFinishedFX;
    public AudioSource MenuMenu;
    public AudioSource DeathFX;
    public AudioSource DashFX;
    public AudioSource GoldArrowFX;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LevelFinish()
    {
        LevelFinishedFX.Play();
    }
    public void Jump()
    {
        JumpFX.Play();
    }
    public void BossStart()
    {
        BossMusic.Play();
    }

    public void MenuMusic()
    {
        MenuMenu.Play();
    }
    public void Die()
    {
        DeathFX.Play();
    }
    public void Dash()
    {
        DashFX.Play();
    }
    public void Gold()
    {
        GoldArrowFX.Play();
    }
}
