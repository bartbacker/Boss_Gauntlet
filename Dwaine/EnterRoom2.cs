using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterRoom2 : MonoBehaviour
{
    public GameObject keyText;
    private bool playerDetected;
    public GameObject playerGo;
    public GameObject healthSlider;
    public GameObject icon;
    public GameObject dwaineExit;
    public GameObject fade;
    public Camera cam;
    public bool bossCanMove;
    private bool doOnceTrigger = true;

    public Animator animator;

    public AudioSource backgroundMusic;
    public AudioSource bossMusic;

    void Start()
    {
        playerDetected = false;
        keyText.SetActive(false);
    }

    void Update()
    {
        if (playerDetected)
        {
            if (bossMove() == true && doOnceTrigger == true)
            {
                playerGo.transform.position = playerGo.transform.position + new Vector3(14, 20, 0);

                fade.SetActive(true);
                animator.SetBool("DoFadeRev", true);

                healthSlider.SetActive(true);
                icon.SetActive(true);
                doOnceTrigger = false;

                backgroundMusic.Pause();
                bossMusic.Play();
            }
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
            keyText.SetActive(false);
        }
    }

    public bool bossMove()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerDetected == true)
        {
            bossCanMove = true;
            return bossCanMove;
        }
        return bossCanMove;
    }
}
