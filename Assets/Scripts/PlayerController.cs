using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private FacingDirection facingDirection = FacingDirection.left;// Variable to track the current facing direction of the player
    public float moveSpeed = 5f;
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
    }

    void Update()
    {
        
        Vector2 playerInput = new Vector2();


    if (Keyboard.current.aKey.isPressed)
    {
        playerInput.x = -1;
    }

    if (Keyboard.current.dKey.isPressed)
    {
        playerInput.x = 1;
    }


    MovementUpdate(playerInput);

    }

    private void MovementUpdate(Vector2 playerInput)
    {
         rb.linearVelocity = new Vector2(playerInput.x * moveSpeed,rb.linearVelocity.y); // Set the linear velocity of the Rigidbody2D based on player input and move speed
    }

    public bool IsWalking()
    {
        // Check if the absolute value of the horizontal velocity is greater than a small threshold to determine if the player is walking
        return Mathf.Abs(rb.linearVelocity.x) > 0.01f;
        
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

    private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.green;

    Vector2 checkPosition = (Vector2)transform.position + groundCheckOffset; 

    Gizmos.DrawWireCube(checkPosition, groundCheckSize);
}

}
