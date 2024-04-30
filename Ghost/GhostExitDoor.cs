using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GhostExitDoor : MonoBehaviour
{
    private bool playerDetected;
    public GameObject playerGo;
    public GameObject ghost;
    public GameObject fade;
    public GameObject ghostWall;
    public bool bossDefeated;

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
            playerGo.transform.position = playerGo.transform.position + new Vector3(-53, -35, 0);

            ghostWall.SetActive(false);
            ghost.SetActive(false);
            fade.SetActive(true);

            animator.SetBool("DoFadeRev", true);

            bossDefeated = false;

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
