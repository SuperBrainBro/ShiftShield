using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalPlayer : MonoBehaviour
{

    //Public Variables
    private GameObject cam;
    public AudioSource Block;
    private DontDestroyScript dontDestroy;

    private GameObject target;
    public Transform bulletPos;
    public GameObject bullet;

    private float fireRate;
    public float startFireRate;
    public float startOffset;

    private float nextFire;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();
        target = GameObject.FindGameObjectWithTag("Corruption");

        fireRate = startFireRate;
        nextFire = Time.time + startOffset;
    }

    private void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            nextFire += fireRate;
        }
    }

    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Block.Play();
            cameraEvent();
        }
    }

    public void cameraEvent()
    {
        StartCoroutine("cameraShake");
    }
    public IEnumerator cameraShake()
    {
        //Create Random Vector2 1
        float xx = Random.Range(-2f, 2f);
        float yy = Random.Range(-2f, 2f);
        Vector3 xy = new Vector3(xx, yy, 0);

        cam.transform.position += (xy);
        yield return new WaitForSeconds(.07f);
        cam.transform.position -= (xy);

        yield return new WaitForSeconds(.08f);

        //Create Random Vector2 2
        xx = Random.Range(-3f, 3f);
        yy = Random.Range(-3f, 3f);
        xy = new Vector3(xx, yy, 0);

        cam.transform.position -= (xy / 2);
        yield return new WaitForSeconds(.07f);
        cam.transform.position += (xy / 2);

        //Create Random Vector2 3
        xx = Random.Range(-2f, 2f);
        yy = Random.Range(-2f, 2f);
        xy = new Vector3(xx, yy, 0);

        cam.transform.position += (xy / 3);
        yield return new WaitForSeconds(.07f);
        cam.transform.position -= (xy / 3);

        yield return new WaitForSeconds(.08f);

        //Create Random Vector2 4
        xx = Random.Range(-2f, 2f);
        yy = Random.Range(-2f, 2f);
        xy = new Vector3(xx, yy, 0);

        cam.transform.position -= (xy / 4);
        yield return new WaitForSeconds(.07f);
        cam.transform.position += (xy / 4);
    }
}
