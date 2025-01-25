using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of horizontal movement
    public float jumpForce = 5f;  // Force applied when jumping upwards

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement (left/right)
        float moveInput = Input.GetAxis("Horizontal");  // A/D or Left/Right Arrow keys
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);  // Only change the X axis

        // Upward movement triggered by pressing Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();  // Call the jump function to move upwards
        }
    }

    void Jump()
    {
        // Apply upward force to the player
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
