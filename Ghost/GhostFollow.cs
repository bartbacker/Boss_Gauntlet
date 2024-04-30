using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour
{
    public Transform target;
    public Ghost ghost;
    public GameObject ghostDoor;

    private void Update()
    {
        if(ghostDoor.GetComponent<EnterRoomGhost>().bossMove() == true)
        {
            var directionTowardsTarget = (target.position - this.transform.position).normalized;
            ghost.MoveTo(directionTowardsTarget);
        }
    }
}
