using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crabcake : MonoBehaviour
{
    public int health;
    public float speed;

    public bool MoveRight;
    public bool digging;

    public Animator anim;

    public GameObject bloodEffect;
    public GameObject exitDoor;
    [SerializeField] private int damage;

    public Slider healthBar;
    public GameObject healthSliderObject;

    public GameObject crabDoor;
    private float time;
    private float time2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(0, rb.velocity.y);

        if (health <= 0)
        {
            //anim.SetBool("Dead", true);
            if (time > 7)
            {
                Destroy(gameObject);
                healthSliderObject.SetActive(false);
                exitDoor.SetActive(true);
            }
        }

        if (MoveRight && crabDoor.GetComponent<EnterRoomCrab>().bossMove() == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }

        if (MoveRight == false && crabDoor.GetComponent<EnterRoomCrab>().bossMove() == true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }

        if (time > Random.Range(3,6) && crabDoor.GetComponent<EnterRoomCrab>().bossMove() == true)
        {
            Debug.Log("DIGGING");
            time = 0;
            StartCoroutine(DigStart());
        }

        healthBar.value = health;
        time += Time.deltaTime;
        time2 += Time.deltaTime;
    }

    IEnumerator DigStart()
    {
        digging = true;
        while (digging == true)
        {
            time += Time.deltaTime;
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            speed = speed * 2;
            if (time > 3)
            {
                digging = false;
                time = 0;

                while (digging == false)
                {
                    time += Time.deltaTime;
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    if (time > 3)
                    {
                        digging = true;
                        speed = speed / 2;
                        time = 0;
                    }
                    yield return null;
                }
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }

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

        if (collision.tag == "Bullet")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        //play hurt sound?
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN!");
    }
}
