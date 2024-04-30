using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dwaine : MonoBehaviour
{
    public int health;
    public float speed;
    private Rigidbody2D rb;
    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    private Rigidbody2D rb3;
    private Rigidbody2D rb4;

    public bool MoveRight;

    public Animator anim;

    public float force;
    public GameObject bloodEffect;
    public GameObject exitDoor;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock_1;
    public GameObject rock_2;
    public GameObject rock_3;
    public GameObject rock_4;
    [SerializeField] private int damage;

    public Slider healthBar;
    public GameObject healthSliderObject;
    public GameObject icon;

    public GameObject dwaineDoor;
    private float time;
    private float time2;

    private bool stopOthers = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb1 = rock1.GetComponent<Rigidbody2D>();
        rb2 = rock2.GetComponent<Rigidbody2D>();
        rb3 = rock3.GetComponent<Rigidbody2D>();
        rb4 = rock4.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (health <= 0)
        {
            stopOthers = true;
            anim.SetBool("Dead", true);
            Debug.Log(time);
            if(time > 8)
            {
                Destroy(gameObject);
                healthSliderObject.SetActive(false);
                icon.SetActive(false);
                exitDoor.SetActive(true);
            }
        }

        if (MoveRight && dwaineDoor.GetComponent<EnterRoom2>().bossMove() == true && stopOthers == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-2, 2);
        }

        if(MoveRight == false && dwaineDoor.GetComponent<EnterRoom2>().bossMove() == true && stopOthers == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(2, 2);
        }

        if (time > 3 && dwaineDoor.GetComponent<EnterRoom2>().bossMove() == true && stopOthers == false)
        {
            rb.AddForce(Vector2.up * 1500);
            time = 0;
        }

        if(time2 > 4 && stopOthers == false)
        {
            bossAttack();
            time2 = 0;
        }

        healthBar.value = health;
        time += Time.deltaTime;
        time2 += Time.deltaTime;
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

    public void bossAttack()
    {
        rock_1 = Instantiate(rock1, this.gameObject.transform.position, Quaternion.identity);       //Create 1 rock
        rock_2 = Instantiate(rock2, this.gameObject.transform.position, Quaternion.identity);       //Create 1 rock
        rock_3 = Instantiate(rock3, this.gameObject.transform.position, Quaternion.identity);       //Create 1 rock
        rock_4 = Instantiate(rock4, this.gameObject.transform.position, Quaternion.identity);       //Create 1 rock

        rock_1.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * force);
        rock_1.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * (force/3));

        rock_2.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * force);
        rock_2.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * (force / 5));

        rock_3.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * force);
        rock_3.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * (force / 3));

        rock_4.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * force);
        rock_4.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * (force / 5));
    }
}
