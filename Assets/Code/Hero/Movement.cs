using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool runMode = false;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private StaminaComponent staminaComponent;
    private InputService inputService;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaComponent = GetComponent<StaminaComponent>();
        inputService = GetComponent<InputService>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FlipX();
        Move();
        Jump();
        UpdateAnimator();
    }

    void FlipX()
    {
        if (inputService.getDirectionX() > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (inputService.getDirectionX() < 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
        }
    }

    void Jump()
    {
        if (inputService.getSpacePressed() && rb.velocity.y == 0 && staminaComponent.currentStamina >= 15)
        {
            staminaComponent.currentStamina -= 15;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        runMode = inputService.getLeftAltPressed();
        if (runMode)
        {
            rb.velocity = new Vector2(runSpeed * inputService.getDirectionX(), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(walkSpeed * inputService.getDirectionX(), rb.velocity.y);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetBool("RunMode", runMode);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}