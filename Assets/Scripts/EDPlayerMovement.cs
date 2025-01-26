using UnityEngine;


public interface ITriggerHandler 
{
  void OnPlayerTrigger();
}

public class EDPlayerMovement : MonoBehaviour, ITriggerHandler
{
    public SoundManager SoundManager;
    public float maxHorizontalSpeed = 5f; // Speed for horizontal movement
    public float maxVerticalSpeed = 1f; // Speed for vertical movement (up/down)

    public float acceleration = 10f;
    private Rigidbody rb; // The Rigidbody component of the 3D model
    private GameObject bubble, crab;
    private Scale scale;

    private void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();

        // Get Scale component in child
        scale = GetComponentInChildren<Scale>();
    }

    //private void LateUpdate()
    // kyle speed fix
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
      //Vector3 force = Vector3.right * (acceleration * horizontalInput / 30);
      // kyle speed fix
      Vector3 force = Vector3.right * (acceleration * horizontalInput);
      
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
        //Vector3 force = Vector3.up * acceleration / 12;
        // kyle speed fix
        Vector3 force = Vector3.up * acceleration;
        
        if(Input.GetKeyDown(KeyCode.Space))
            SoundManager.PlayRandomBlowSound();

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

    public void OnPlayerTrigger() {

    }
}
