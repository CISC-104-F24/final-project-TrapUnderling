using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // Speed of the player
    public float moveSpeed = 5f;
    
    // Reference to the player's Rigidbody2D
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the horizontal and vertical axis (WASD/Arrow keys)
        // Wanted to try to challenge myself and use a different script line that allows my player to move using the WASD keys other than the keys we've already used.
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrow keys
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrow keys

        // Create a movement vector based on the input
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Move the player using Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }
}
