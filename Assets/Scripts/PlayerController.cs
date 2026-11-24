using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private FacingDirection facingDirection = FacingDirection.left;// Variable to track the current facing direction of the player
    public float moveSpeed = 5f;
    private Rigidbody2D rb;



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
        
        return true;
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
}
