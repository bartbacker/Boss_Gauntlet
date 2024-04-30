using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    private GameObject play;
    private GameObject option;
    private GameObject quit;

    void Awake()
    {
        play = GameObject.Find("PlayButton");
        option = GameObject.Find("OptionsButton");
        quit = GameObject.Find("QuitButton");
    }

    public void PlayGame()
    {

        StartCoroutine(waiter());

        IEnumerator waiter()
        {
            play.SetActive(false);
            option.SetActive(false);
            quit.SetActive(false);
            animator.SetBool("DoFade", true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StopAnim()
    {
        animator.SetBool("DoFade", false);
    }

    public void startUnpause()
    {
        animator.speed = 1;
    }

    public void startPause()
    {
        animator.speed = 0;
    }
}
