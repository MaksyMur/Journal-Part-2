using UnityEngine;
using System.Collections.Generic;

public class PuddleOverlap : MonoBehaviour
{
    private Collider2D puddleCollider;
    private List<Collider2D> results = new List<Collider2D>(); // List to hold the results of the overlap check

    private bool cubeAFound = false;

    void Start()
    {
        puddleCollider = GetComponent<Collider2D>(); // Get the Collider2D component attached to this GameObject
    }

    void FixedUpdate()
    {
        int count = Physics2D.OverlapCollider(puddleCollider, results); // Check for overlaps with the puddle's collider

        for (int i = 0; i < count; i++)
        {
            Collider2D other = results[i];

            if (other.gameObject.name == "TestExtrapolate" && !cubeAFound) // Check if the overlapping object is "TestExtrapolate" and if it hasn't been found yet
    {
        Debug.Log("TestExtrapolate entered the puddle!");
        cubeAFound = true;
    }

    if (other.gameObject.name == "TestNone")
    {
         Destroy(other.gameObject);
    }



        }
    }
}
