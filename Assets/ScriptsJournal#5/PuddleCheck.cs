using UnityEngine;

public class PuddleCheck : MonoBehaviour
{
    public Transform puddle;

    private Rigidbody2D rb;
    private bool wasOverPuddle = false; // Variable to track if the cube was over the puddle in the previous frame

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }

    void FixedUpdate()
    {
        bool isOverPuddle = rb.OverlapPoint(puddle.position); // Check if the Rigidbody2D is currently over the puddle

        if (isOverPuddle && !wasOverPuddle) // If the cube is over the puddle and it wasn't in the previous frame
        {
            Debug.Log("You entered the puddle!");
        }

        wasOverPuddle = isOverPuddle; 
    }
}
