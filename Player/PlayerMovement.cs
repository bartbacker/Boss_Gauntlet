using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{

    public Animator animatorMove;

    public float speed; 
    public float jump;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableGroundPlatform;

    private BoxCollider2D coll;
    public bool isJumping;

    private Rigidbody2D rb;
    public float checkRadius;
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    public Light2D light;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animatorMove = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Movement and Turning
        float Move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        //Checks running
        if(Move == 0)
        {
            animatorMove.SetBool("isRunning", false);
        }
        else
        {
            animatorMove.SetBool("isRunning", true);
        }

        //Checks turning
        /*if (Move < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/

        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded() || isGroundedP()))
        {
            rb.velocity = Vector2.up * jump;
            animatorMove.SetBool("isJumping", true);
        }

        if(isGrounded() == true || isGroundedP() == true)
        {
            animatorMove.SetBool("isJumping", false);
        }
        else
        {
            animatorMove.SetBool("isJumping", true);
        }

        //Wall Jumping and Sliding
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, jumpableGround);

        if (isTouchingFront == true && isJumping == true && Move != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LightChange")
        {
            light.intensity = 10f;
        }
    }

        //Check if Jumping
        private void OnCollisionExit2D(Collision2D JumpDetector)
    {
        if (JumpDetector.gameObject.CompareTag("Ground") || JumpDetector.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = true;
        }
    }

    //Check if on the ground
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool isGroundedP()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGroundPlatform);
    }
}
