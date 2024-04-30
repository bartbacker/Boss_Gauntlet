using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private const float ForcePower = 10f;

    public new Rigidbody2D rigidbody;

    public float speed = 1f;
    public float force = 1f;

    private Vector2 direction;

    [SerializeField] private int damage;

    public GameObject ghostExitDoor;
    public GameObject ghostBoss;

    public void MoveTo(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Stop()
    {
        MoveTo(Vector2.zero);
    }

    private void FixedUpdate()
    {
        var desiredVelocity = direction * speed;
        var deltaVelocity = desiredVelocity - rigidbody.velocity;
        Vector3 moveForce = deltaVelocity * (force * ForcePower * Time.fixedDeltaTime);
        rigidbody.AddForce(moveForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

}
