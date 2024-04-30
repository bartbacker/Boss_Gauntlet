using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DwaineExitDoor : MonoBehaviour
{
    private bool playerDetected;
    public GameObject playerGo;
    public GameObject fade;
    public GameObject dwaineDoor;
    public GameObject ghostWall;

    public Animator animator;

    public AudioSource backgroundMusic;
    public AudioSource bossMusic;

    void Start()
    {
        playerDetected = false;
    }

    void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            playerGo.transform.position = playerGo.transform.position + new Vector3(-18, -14, 0);
            dwaineDoor.GetComponent<EnterRoom2>().bossCanMove = false;

            ghostWall.SetActive(false);
            fade.SetActive(true);

            animator.SetBool("DoFadeRev", true);

            backgroundMusic.Play();
            bossMusic.Pause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
            playerGo = collision.gameObject;
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
