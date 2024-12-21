using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private bool runMode = false;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private StaminaComponent staminaComponent;
    private AnimStateMachine anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaComponent = GetComponent<StaminaComponent>();
        anim = GetComponent<AnimStateMachine>();
    }

    void Update()
    {
        InputHandler();
        Idle();
        Move();
        Jump();
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            runMode = !runMode;
        }
    }

    void Idle()
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            anim.isIdle = true;
            anim.isWalk = false;
            anim.isRun = false;
        }
        else
        {
            anim.isIdle = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0 && staminaComponent.currentStamina >= 15)
        {
            staminaComponent.currentStamina -= 15;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            if (runMode)
            {
                anim.isRun = true;
                anim.isWalk = false;
                staminaComponent.currentStamina -= 1 * Time.deltaTime;
                rb.AddForce(new Vector2(runSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
            }
            else
            {
                anim.isWalk = true;
                anim.isRun = false;
                rb.AddForce(new Vector2(walkSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
            if (runMode)
            {
                anim.isRun = true;
                anim.isWalk = false;
                staminaComponent.currentStamina -= 1 * Time.deltaTime;
                rb.AddForce(new Vector2(runSpeed * Time.deltaTime * -1, 0), ForceMode2D.Impulse);
            }
            else
            {
                anim.isWalk = true;
                anim.isRun = false;
                rb.AddForce(new Vector2(walkSpeed * Time.deltaTime * -1, 0), ForceMode2D.Impulse);
            }
        }
    }

}