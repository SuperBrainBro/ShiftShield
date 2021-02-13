using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionBulletSpawner : MonoBehaviour
{
    private GameObject target;
    private GameObject cam;

    public GameObject bulletOBJ;
    public GameObject bigBulletOBJ;

    private GameObject bullet;
    private  GameObject bigBullet;

    private float fireRate;
    public float startFireRate;
    public float startOffset;

    private float nextFire;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;

    private int eye = 1;

    public bool incremental = false;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        fireRate = startFireRate;
        nextFire = Time.time + startOffset;
    }
    void Update()
    {
        bullet = bulletOBJ;
        bullet.GetComponent<laserScript>().realSpeed = bullet.GetComponent<laserScript>().moveSpeed + cam.GetComponent<PlatformerCamera>().speed * 2;
        bigBullet = bigBulletOBJ;
        bigBullet.GetComponent<laserScript>().realSpeed = bigBullet.GetComponent<laserScript>().moveSpeed + cam.GetComponent<PlatformerCamera>().speed * 2;
        CheckIfTimeToFire(eye);
    }

    void CheckIfTimeToFire(int eyeV)
    {
        if (Time.time > nextFire)
        {
            StartCoroutine(SecondShoot(eye));

            //nextFire = Time.time + fireRate;
        }
    }
    IEnumerator SecondShoot(int eyeV)
    {
        //Debug.LogError("Switch Not Work");
        switch (eye)
        {
            
            case 1:
                if (incremental)
                {
                    if (fireRate < .25)
                    {
                        fireRate -= .025f;
                    }
                }
                //Debug.LogError("Switch Work");
                nextFire = Time.time + fireRate;
                eye = 2;
                Instantiate(bullet, pos1.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos1.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos1.transform.position, Quaternion.identity);
                break;
            case 2:
                if (incremental)
                {
                    if (fireRate < .25)
                    {
                        fireRate -= .025f;
                    }
                }
                //Debug.LogError("Switch Work");
                nextFire = Time.time + fireRate;
                eye = 3;
                Instantiate(bullet, pos2.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos2.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos2.transform.position, Quaternion.identity);
                break;
            case 3:
                if (incremental)
                {
                    if (fireRate < .25)
                    {
                        fireRate -= .025f;
                    }
                }
                //Debug.LogError("Switch Work");
                nextFire = Time.time + fireRate;
                eye = 4;
                Instantiate(bigBullet, pos3.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);
                Instantiate(bigBullet, pos3.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);
                Instantiate(bigBullet, pos3.transform.position, Quaternion.identity);
                break;
            case 4:
                if (incremental)
                {
                    if (fireRate < .25)
                    {
                        fireRate -= .025f;
                    }
                }
                //Debug.LogError("Switch Work");
                nextFire = Time.time + fireRate;
                eye = 5;
                Instantiate(bullet, pos4.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos4.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos4.transform.position, Quaternion.identity);
                break;
            case 5:
                if (incremental)
                {
                    if (fireRate < .25)
                    {
                        fireRate -= .025f;
                    }
                }
                //Debug.LogError("Switch Work");
                nextFire = Time.time + fireRate;
                eye = 1;
                Instantiate(bullet, pos5.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos5.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                Instantiate(bullet, pos5.transform.position, Quaternion.identity);
                break;
        }

    }

}
