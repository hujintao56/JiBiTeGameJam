using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Player player;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private float horizontalMovement;
    private bool is_down;
    private PolygonCollider2D plgcol;
    public Transform weapenObj;
    public int facingDirection = 1;
    private Collision2D cloudCol;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource runSoundEffect;
    private Animator animator;
    private void Start()
    {
        //weapenObj = transform.Find("weapon");
        rb = GetComponent<Rigidbody2D>();
        plgcol = GetComponentInChildren<PolygonCollider2D>();
        player = GetComponentInParent<Player>();
        animator = player.transform.GetComponentInChildren<Animator>();
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

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            runSoundEffect.Play();
        else
            runSoundEffect.Pause();

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false;
            jumpSoundEffect.Play();
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpForce - rb.velocity.y), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            Invoke("JumpCancel", 1f);
        }
        if (rb.velocity.y == 0)
        {
            //rb.velocity = new Vector2(0,-3);
        }
    }

    private void JumpCancel()
    {
        animator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        if (horizontalMovement != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);

        if (isJumping && rb.velocity.y < 0f)
        {
            isJumping = false;
        }
        if (horizontalMovement > 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            plgcol.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            weapenObj.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (horizontalMovement < 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
            plgcol.gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
            weapenObj.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (cloudCol != null)
            {
                cloudCol.collider.isTrigger = true;
                is_down = true;
            }
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
        isGrounded = false;
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("cloud"))
        {

        }
        if (collision.gameObject.CompareTag("cloud"))
        {
            collision.collider.isTrigger = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("cloud"))
        {
            cloudCol = collision;
            isGrounded = true;
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

    public void WindWashself()
    {
        rb.velocity = new Vector2(facingDirection * 10, rb.velocity.y);
    }

}