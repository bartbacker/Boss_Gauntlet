using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    public Animator animator;
    public GameObject target;
    public GameObject ghostDoor;
    private GameObject fade;
    public GameObject dwaineDoor;
    public GameObject dwaineCam;
    private bool DoOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("FadeOut");
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -1);
        fade.SetActive(true);
        animator.SetBool("DoFadeRev", true);

        if (dwaineDoor.GetComponent<EnterRoom2>().bossMove() == true && DoOnce == true)
        {
            transform.position = dwaineCam.transform.position;
            DoOnce = false;
        }
        if (ghostDoor.GetComponent<EnterRoomGhost>().bossMove() == true)
        {
            transform.position = target.transform.position;
        }
    }

    public void StopAnim()
    {
        animator.SetBool("DoFadeRev", false);
        fade.SetActive(false);
    }
}
