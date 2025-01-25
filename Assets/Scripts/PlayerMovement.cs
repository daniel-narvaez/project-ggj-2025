using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;      // Maximum speed for horizontal movement
    public float baseAcceleration; // Rate of acceleration
    public float baseDeceleration; // Rate of deceleration
    public float upwardForce;   // Force applied when moving upwards

    private Rigidbody2D rb;
    private float currentSpeed = 0f; // Current horizontal speed

    private SpriteScaler spriteScaler;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();

        // Get the SpriteScaler component
        spriteScaler = GetComponentInChildren<SpriteScaler>();
        
    }

    void Update()
    {
        // Get the current sprite scale
        float spriteScale = transform.localScale.x; // Assuming uniform scale

        // Adjust acceleration and deceleration based on sprite scale
        float adjustedAcceleration = baseAcceleration * spriteScale * (spriteScaler.currentScale * 100);
        float adjustedDeceleration = baseDeceleration * spriteScale * (spriteScaler.currentScale * 100);
        Debug.Log("accel " + adjustedAcceleration);
        Debug.Log("decel " + adjustedDeceleration);

        // Horizontal movement input (left/right)
        float moveInput = Input.GetAxis("Horizontal");  // A/D or Left/Right Arrow keys

        if (moveInput != 0)
        {
            // Accelerate towards maxSpeed in the direction of input
            currentSpeed += moveInput * baseAcceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed); // Clamp to max speed
        }
        else
        {
            // Decelerate when no input
            if (currentSpeed > 0)
            {
                currentSpeed -= baseDeceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += baseDeceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, 0);
            }
        }

        // Apply horizontal velocity
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        // Upward movement when Space key is held down
        if (Input.GetKey(KeyCode.Space))
        {
            MoveUp(); // Call the function to move the player upward
        }
    }

    void MoveUp()
    {
        // Apply a continuous upward force to the player when Space is held
        rb.velocity = new Vector2(rb.velocity.x, upwardForce); // Only modify the Y axis (upward movement)
    }
    bool IsObjectAtBottom()
    {
        // Get the camera's orthographic size (half the height of the screen in world units)
        float cameraHeight = Camera.main.orthographicSize;

        // Get the Y position of the object
        float objectYPosition = transform.position.y;

        // Check if the object's Y position is less than the bottom of the camera view
        return objectYPosition <= -cameraHeight;
    }

    bool IsObjectAtTop()
    {
        // Get the camera's orthographic size (half the height of the screen in world units)
        float cameraHeight = Camera.main.orthographicSize;

        // Get the Y position of the object
        float objectYPosition = transform.position.y;

        // Check if the object's Y position is greater than the top of the camera view
        return objectYPosition >= cameraHeight;
    }

}
