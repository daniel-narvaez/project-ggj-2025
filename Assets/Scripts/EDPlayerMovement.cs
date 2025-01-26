using UnityEngine;

public class EDPlayerMovement : MonoBehaviour
{
    public float maxHorizontalSpeed = 5f; // Speed for horizontal movement
    public float maxVerticalSpeed = 2f; // Speed for vertical movement (up/down)

    public float acceleration = 10f;
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
      float horizontalInput = Input.GetAxis("Horizontal");
      Vector3 force = Vector3.right * (acceleration * horizontalInput / 15);
      
      // Speed reduces as scale increases
      float speedMultiplier = 1 - (scale.currentScale / scale.maxScale);
      float adjustedMaxSpeed = maxHorizontalSpeed * speedMultiplier;
      
      rb.AddForce(force);
      
      Vector3 clampedVelocity = rb.velocity;
      clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -adjustedMaxSpeed, adjustedMaxSpeed);
      rb.velocity = clampedVelocity; 
  }

    // Handle vertical movement (up/down) with Spacebar
    private void MoveVertically()
    {
        Vector3 force = Vector3.up * acceleration / 6;
        
        if (Input.GetKey(KeyCode.Space) && scale.currentScale < scale.maxScale)
        {
            rb.AddForce(force);
        }
        
        // Clamp vertical velocity
        float maxSpeed = maxVerticalSpeed / scale.currentScale;
        Vector3 clampedVelocity = rb.velocity;
        clampedVelocity.y = Mathf.Clamp(clampedVelocity.y, -maxSpeed, maxSpeed);
        rb.velocity = clampedVelocity;
    }
}
