using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlatform : MonoBehaviour
{
    public float speed;
    public bool targetShot;
    public bool MoveUp;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveUp && targetShot == true)
        {
            if(this.gameObject.tag == "HorizonPlatform")
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (this.gameObject.tag == "VerticaPlatform")
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }

        if (MoveUp == false && targetShot == true)
        {
            if (this.gameObject.tag == "HorizonPlatform")
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (this.gameObject.tag == "VerticaPlatform")
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turn")
        {
            if (MoveUp)
            {
                MoveUp = false;
            }
            else
            {
                MoveUp = true;
            }
        }
    }
}
