using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    //Private Variables
    private bool faceUp = false;
    private bool faceLeft = false;
    private bool faceDown = false;
    private bool faceRight = false;

    //Public Variables
    public AudioSource Block;
    public Camera cam;
    public string loseScreen;
    private DontDestroyScript dontDestroy;
    private void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Dont Destroy").GetComponent<DontDestroyScript>();

        faceUp = setActive();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            faceUp = setActive();
            Debug.Log("Up Button Detected" + faceUp);
        }
        if (Input.GetButtonDown("Left"))
        {
            faceLeft = setActive();
            Debug.Log("Left Button Detected" + faceLeft);
        }
        if (Input.GetButtonDown("Down"))
        {
            faceDown = setActive();
            Debug.Log("Down Button Detected" + faceDown);
        }
        if (Input.GetButtonDown("Right"))
        {
            faceRight = setActive();
            Debug.Log("Right Button Detected" + faceRight);
        }
    }

    public bool setActive()
    {
        faceUp = false;
        faceLeft = false;
        faceDown = false;
        faceRight = false;

        return true;
    }
    private void FixedUpdate()
    {
        if (faceUp)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (faceLeft)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (faceDown)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (faceRight)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.GetComponent<ArrowScript>() != null)
            {
                switch (collision.gameObject.GetComponent<ArrowScript>().directionSent)
                {
                    //Come From Right
                    case 0:
                        if (!faceRight)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                    //Come From Up
                    case 1:
                        if (!faceUp)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                    //Come From Left
                    case 2:
                        if (!faceLeft)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                    //Come From Down
                    case 3:
                        if (!faceDown)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                }
            }
            if (collision.gameObject.GetComponent<YellowArrowScript>() != null)
            {
                switch (collision.gameObject.GetComponent<YellowArrowScript>().directionSent)
                {
                    //Come From Right
                    case 0:
                        if (!faceRight)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                    //Come From Up
                    case 1:
                        if (!faceUp)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                    //Come From Left
                    case 2:
                        if (!faceLeft)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                    //Come From Down
                    case 3:
                        if (!faceDown)
                        {
                            dontDestroy.Die();
                            SceneManager.LoadScene(loseScreen);
                            Debug.Log("Killed Player");
                            dontDestroy.BossMusic.Stop();
                            //Time.timeScale = 0;
                        }
                        break;
                }
            }
            Destroy(collision.gameObject);
            Block.Play();
            cameraEvent();
        }
    }

    public void cameraEvent()
    {
        StartCoroutine("cameraShake");
        if (cam.orthographicSize < 90)
        {
            cam.orthographicSize += 2.5f;
        }   
    }
    public IEnumerator cameraShake()
    {       
        //Create Random Vector2 1
        float xx = Random.Range(-2f, 2f);
        float yy = Random.Range(-2f, 2f);
        Vector3 xy = new Vector3(xx, yy, 0);

        cam.transform.position += (xy);
        cam.orthographicSize -= xx;
        yield return new WaitForSeconds(.07f);
        cam.orthographicSize += xx;
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
        cam.orthographicSize -= yy;
        yield return new WaitForSeconds(.07f);
        cam.orthographicSize += yy;
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