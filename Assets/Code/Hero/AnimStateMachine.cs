using UnityEngine;

public class AnimStateMachine : MonoBehaviour
{
    public bool isRun;
    public bool isWalk;
    public bool isIdle;

    // private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isIdle)
        {
            animator.Play("Idle");
        }
        else if (isWalk)
        {
            animator.Play("Walk");
        }
        else if (isRun)
        {
            animator.Play("Run");
        }
    }
}
