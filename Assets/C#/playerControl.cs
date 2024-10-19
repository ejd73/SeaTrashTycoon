using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    // Animator component reference
    private Animator animator;
    private Vector2 movement; // Store movement direction

    void Start()
    {
        animator = GetComponent<Animator>(); // Get Animator component attached to the player
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal"); // A (-1) or D (+1)
        movement.y = Input.GetAxisRaw("Vertical"); // W (+1) or S (-1)

        // Set animation states based on input
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void UpdateAnimation()
    {
        // Reset all movement triggers
        animator.ResetTrigger("Up");
        animator.ResetTrigger("Down");
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Right");

        // Set animation based on movement direction
        if (movement.y > 0)
        {
            animator.SetTrigger("walkUp"); // Play 'Up' animation
        }
        else if (movement.y < 0)
        {
            animator.SetTrigger("walkDown"); // Play 'Down' animation
        }
        else if (movement.x < 0)
        {
            animator.SetTrigger("walkLeft"); // Play 'Left' animation
        }
        else if (movement.x > 0)
        {
            animator.SetTrigger("walkRight"); // Play 'Right' animation
        }
    }
}
