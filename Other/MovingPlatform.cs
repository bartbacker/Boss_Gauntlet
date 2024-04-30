using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    public GameObject ghostDoor;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (MoveRight && ghostDoor.GetComponent<EnterRoomGhost>().bossMove() == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //transform.localScale = new Vector2(-0.35, 0.2);
        }

        if (MoveRight == false && ghostDoor.GetComponent<EnterRoomGhost>().bossMove() == true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //transform.localScale = new Vector2(0.35, 0.2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turn")
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        col.transform.SetParent(null);
    }

}
