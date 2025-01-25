using UnityEngine;

public class EDPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed for horizontal movement
    public float verticalSpeed = 2f; // Speed for vertical movement (up/down)

    private Rigidbody rb; // The Rigidbody component of the 3D model
    private Scale scale;

    private void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();

        // Get Scale component in child
        scale = GetComponentInChildren<Scale>();
    }

    private void Update()
    {
      if (GameStateManager.Instance.currentState != GameState.Play)
      {
        rb.isKinematic = true;
        return;
      }

        rb.isKinematic = false;
        MoveHorizontally();
        MoveVertically();
    }

    // Handle horizontal movement (left/right) with arrow keys or 'A' and 'D'
    private void MoveHorizontally()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        Vector3 horizontalMovement = new Vector3(horizontalInput * moveSpeed * (scale.maxScale - scale.currentScale), 0, 0); // Only move along X-axis

        // Apply horizontal movement while preserving Y and Z velocity
        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, rb.velocity.z); 
    }

    // Handle vertical movement (up/down) with Spacebar
    private void MoveVertically()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Move up when Space is held down
            rb.velocity = new Vector3(rb.velocity.x, verticalSpeed, rb.velocity.z);
        }
        else
        {
            // Move down when Space is released (gravity takes over)
            // Optional: adjust this for more realistic fall speed
            rb.velocity = new Vector3(rb.velocity.x, -verticalSpeed, rb.velocity.z); 
        }
    }
}
