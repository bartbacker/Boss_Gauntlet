using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    public GameObject dwaineDoor;
    public GameObject ghostDoor;
    public GameObject dwaineCam;
    private 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dwaineDoor.GetComponent<EnterRoom2>().bossMove() == true)
        {
            transform.position = new Vector3(dwaineCam.transform.position.x, (dwaineCam.transform.position.y), -10);
            cam.orthographicSize = 5;
        }
        else
        {
            transform.position = new Vector3(target.transform.position.x, (target.transform.position.y), -10);
            cam.orthographicSize = 4;
        }
    }
}
