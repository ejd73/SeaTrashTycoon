using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    void Start()
    {
        // Get the Animator and Rigidbody2D components
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get player input for WASD or arrow keys
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        // Determine the animation to play based on input
        if (_movement.x > 0)
        {
            _animator.Play("walkRight");
        }
        else if (_movement.x < 0)
        {
            _animator.Play("walkLeft");
        }
        else if (_movement.y > 0)
        {
            _animator.Play("walkUp");
        }
        else if (_movement.y < 0)
        {
            _animator.Play("walkDown");
        }
        else
        {
            _animator.Play("Idle"); // Play idle if no movement
        }

        // Move the player
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Move the player based on input
        Vector2 newPosition = _rb.position + _movement * moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);
    }
}
