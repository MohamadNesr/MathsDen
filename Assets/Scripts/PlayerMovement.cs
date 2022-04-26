using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    public Animator animator;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>(); //rb equals the rigidbody on the player
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontalMovement, verticalMovement, 0) * speed;

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        if (characterVelocity == 0) {
            characterVelocity = Mathf.Abs(rb.velocity.y);
            animator.SetBool("HorizontalMovement", false);
            if (rb.velocity.y > 0) {
                animator.SetBool("UpMovement", true);
                animator.SetBool("DownMovement", false);
            } else if (rb.velocity.y < 0) {
                animator.SetBool("UpMovement", false);
                animator.SetBool("DownMovement", true);
            } else {
                animator.SetBool("UpMovement", false);
                animator.SetBool("DownMovement", false);
            }
        } else {
            animator.SetBool("HorizontalMovement", true);
            animator.SetBool("UpMovement", false);
            animator.SetBool("DownMovement", false);
        }
        animator.SetFloat("Speed", characterVelocity);

    }

    void Flip(float velocity) {
        if (velocity > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }
}