using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrimply : MonoBehaviour
{
    public GameObject keyText;
    private bool playerDetected;
    public GameObject playerGo;
    public Camera cam;
    private float time;
    public bool startText = false;
    public GameObject InteractText;

    void Start()
    {
        playerDetected = false;
        keyText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerDetected)
        {
            //StartCoroutine(TextStart()); SCRAPPED IDEA
            InteractText.SetActive(false);
            startText = true;
        }
    }

    //SCRAPPED IDEA: Zoom in on Scrimply and Player. 
    //Reason for removal: I would have to add a separate button for exiting out of the conversation and changing camera size (the idea is possible but the result would probably be lackluster and unnecessary)
    /*IEnumerator TextStart()
    {
        while (startText == false)
        {
            time += Time.deltaTime;
            if (time > 0.2)
            {
                cam.orthographicSize = cam.orthographicSize - time;
                if(cam.orthographicSize < 3)
                {
                    startText = true;
                }
            }
            yield return null;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
            playerGo = collision.gameObject;
            keyText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
            keyText.SetActive(false);
        }
    }

}
