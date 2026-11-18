using UnityEngine;
using System.Collections;

public class InterpolationTest : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Collider2D[] contacts = new Collider2D[5]; // Array to hold the contacts of the Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime); // Move the Rigidbody2D to the right at a constant speed

        int contactCount = rb.GetContacts(contacts); // Get the number of contacts the Rigidbody2D is currently in

        for (int i = 0; i < contactCount; i++)
        {
            if (contacts[i].gameObject.name == "Wall")
            {
                Debug.Log("Cube is touching Wall!");
            }
        }

    
    }
}

