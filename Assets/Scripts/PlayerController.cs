using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
//checking


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
        return false;
    }
    public bool IsGrounded()
    {
        return false;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
