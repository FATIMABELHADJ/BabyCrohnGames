using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float sickSpeed = 1f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    public bool facingRight = true; // اجعلها public

    private bool isGrounded;
    private bool isSick = false;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Vector2 movement;

    public SickUIManager sickUIManager; // مرجع لسكربت SickUIManager

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isSick)
        {
            animator.SetBool("isRunning", false);
            moveSpeed = sickSpeed;
        }
        else
        {
            moveSpeed = 2f;
            animator.SetBool("isRunning", Input.GetAxisRaw("Horizontal") != 0);
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0f);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (moveX > 0 && !facingRight)
            Flip();
        else if (moveX < 0 && facingRight)
            Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void BecomeSick()
    {
        if (!isSick)
        {
            isSick = true;
            animator.SetTrigger("Sick");
            Debug.Log("🚨 الطفل مرض!");
            if (sickUIManager != null)
            {
                sickUIManager.ShowSickMessage("🚨 الطفل مرض! لازم يروح للمستشفى!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SickZone"))
        {
            BecomeSick();
        }
    }
}
