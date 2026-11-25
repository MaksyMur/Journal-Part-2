using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private FacingDirection facingDirection = FacingDirection.left;// Variable to track the current facing direction of the player
    public float moveSpeed = 5f;


    public float jumpForce = 5f;
    public float fallingSpeed = 5f;
    public float apexHeight = 3f; // Height at which the player reaches the apex of the jump
    public float apexTime = 0.5f; // Time it takes for the player to reach the apex of the jump
    private float terminalVelocity; // Maximum downward speed of the player
    private bool isJumping = false; // Variable to track if the player is currently jumping

    private Rigidbody2D rb;

    public Vector2 groundCheckSize; // Size of the box used for ground checking
    public Vector2 groundCheckOffset; // Offset of the box used for ground checking relative to the player's position



    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
         rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject

         gravity = -2 * apexHeight / Mathf.Pow(apexTime, 2); // Calculate gravity based on apex height and time
         jumpForce = 2 * apexHeight / apexTime; // Calculate jump force based on gravity and apex time
         terminalVelocity = gravity; // Calculate terminal velocity based on gravity and apex height
    }

    void Update()
    {
        
        Vector2 playerInput = new Vector2();


    if (Keyboard.current.aKey.isPressed)
    {
        playerInput.x += -1;
        facingDirection = FacingDirection.left; // Update facing direction when moving left
    }

    if (Keyboard.current.dKey.isPressed)
    {
        playerInput.x += 1;
        facingDirection = FacingDirection.right; // Update facing direction when moving right
    }

    if (Keyboard.current.wKey.wasPressedThisFrame && IsGrounded) // Check if the jump key is pressed and the player is grounded!
    {
        
        isJumping = true; // Set the jumping state to true when the jump key is pressed
    }

        MovementUpdate(playerInput);

    }

    private void MovementUpdate(Vector2 playerInput)
    {
         rb.linearVelocity = new Vector2(playerInput.x * moveSpeed,playerInput.y * jumpForce); // Set the linear velocity of the Rigidbody2D based on player input and move speed
    }

    public bool IsWalking()
    {
        // Check if the absolute value of the horizontal velocity is greater than a small threshold to determine if the player is walking
        return Mathf.Abs(rb.linearVelocity.x) > 0.01f;
        
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    public bool IsGrounded()
    {
        //Calculate the position to check for ground based on the player's position and the ground check offset
       Vector2 checkPosition = (Vector2)transform.position + groundCheckOffset;

    //Perform an overlap box check at the calculated position with the specified size to determine if the player is grounded
    Collider2D[] results = Physics2D.OverlapBoxAll(checkPosition, groundCheckSize, 0f);

    //Iterate through the results of the overlap check to see if any of the colliders belong to the ground tilemap
    foreach (Collider2D other in results)
    {
        if (other.gameObject.name == "GroundTilemap")
        {
            return true;
        }
    }

    return false;
    }

    public FacingDirection GetFacingDirection()
    {
        if (rb.linearVelocity.x < -0.01f) 
    {
        facingDirection = FacingDirection.left;
    }
    else if (rb.linearVelocity.x > 0.01f)
    {
        facingDirection = FacingDirection.right;
    }
        return facingDirection;
    }

    private void FixedUpdate()
    {
       if(isJumping)
       {
           velocity = jumpForce; // Set the vertical velocity to the jump force when jumping
           isJumping = false; // Reset the jumping state after applying the jump force
       }
    }

    private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.green;

    Vector2 checkPosition = (Vector2)transform.position + groundCheckOffset; 

    Gizmos.DrawWireCube(checkPosition, groundCheckSize);
}

}
