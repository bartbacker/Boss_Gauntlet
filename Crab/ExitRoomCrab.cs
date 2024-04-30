using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoomCrab : MonoBehaviour
{
    private bool playerDetected;
    public GameObject keyText;

    public GameObject playerGo;
    public GameObject fade;
    public GameObject crabDoor;

    public Animator animator;

    public AudioSource backgroundMusic;
    //public AudioSource bossMusic;

    void Start()
    {
        playerDetected = false;
        keyText.SetActive(false);
    }

    void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            playerGo.transform.position = playerGo.transform.position + new Vector3(-18, -14, 0);
            crabDoor.GetComponent<EnterRoomCrab>().bossCanMove = false;

            //ghostWall.SetActive(false); (TELEPORT SCRIMPLY HERE)
            fade.SetActive(true);

            animator.SetBool("DoFadeRev", true);

            backgroundMusic.Play();
            //bossMusic.Pause();
        }
    }

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
        }
    }
}
