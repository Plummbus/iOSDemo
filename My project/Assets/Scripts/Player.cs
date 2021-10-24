using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;           //how fast we move forward
    public float directionalSpeed;      //how fast we move left/right
    public AudioClip scoreup;
    public AudioClip damage;

    public Rigidbody rb;
    public GameObject sceneManager;
    public float rotateModifier;



    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position,
            new Vector3 (Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z),
            directionalSpeed * Time.deltaTime);
#endif
        rb.velocity = Vector3.forward * 1000 * Time.deltaTime;
        transform.Rotate(Vector3.right * GetComponent<Rigidbody>().velocity.z / rotateModifier); //rotateModifier is just a modifier for our rotate speed

        //MOBILE CONTROLS
        //a finger works as a substitue for the mouse
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));    //for Camera.main to work, need to give camera the tag "MainCamera"
        if (Input.touchCount > 0)   //whenever something touches the screen
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z); //only need x value of fingers
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreup")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreup, 1.0f);
        }

        if (other.gameObject.tag == "triangle")
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Initialize>().GameOver();
        }
    }
}


