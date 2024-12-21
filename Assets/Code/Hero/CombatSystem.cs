using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private InputService inputService;
    private Animator animator;

    void Start()
    {
        inputService = GetComponent<InputService>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("MouseLeftClick", inputService.getMouseLeftClick());
        // Debug.Log(animator.velocity);
    }
}
