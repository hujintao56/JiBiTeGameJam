using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private float horizontalMovement;
    private bool is_down;
    private PolygonCollider2D plgcol;
    public int facingDirection = 1;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        plgcol = GetComponentInChildren<PolygonCollider2D>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingDirection = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            facingDirection = -1;
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded )
        {
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpForce - rb.velocity.y), ForceMode2D.Impulse);
        }
        if (rb.velocity.y == 0 )
        {
            rb.velocity = new Vector2(0,-3);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);

        if (isJumping && rb.velocity.y < 0f)
        {
            isJumping = false;
        }
        if (horizontalMovement > 0)
        {
            plgcol.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (horizontalMovement < 0)
        {
            plgcol.gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("cloud"))
        {
            isGrounded = true;
            is_down = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("cloud"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("cloud"))
        {
            collision.collider.isTrigger = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        if (Input.GetKeyDown(KeyCode.S) && collision.gameObject.CompareTag("cloud"))
        {
            collision.collider.isTrigger = true;
            is_down = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cloud") && !is_down)
        {
            collision.isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cloud") && rb.velocity.y < 0)
        {
            collision.isTrigger = false;
        }
    }

}