using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 18f;
    private float jumpingPower = 15f;
    public int maxJumps = 2;
    private bool isFacingRight = true;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource jumpSoundEffect;

    public GameObject BackToMainMenuButton;
    public GameObject FinishText;
    public GameObject GoToNextLevel;

    void Start()
    {
        BackToMainMenuButton.SetActive(false);
        FinishText.SetActive(false);
        GoToNextLevel.SetActive(false);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("velocity_x", rb.velocity.x);
        animator.SetFloat("velocity_y", rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpSoundEffect.Play();
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}