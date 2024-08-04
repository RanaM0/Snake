using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the snake's movement
    private Vector2 direction = Vector2.right; // Initial direction (moving right)
    private float xdirection = 59.5f;
    private float ydirection = 32.5f;
    private GameManager gm;

    private void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }
    void Update()
    {
        HandleInput();
        Move();
        snakePositioning();
    }
    // Handle input from the player to change the snake's direction
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up; // Move up
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down; // Move down
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left; // Move left
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right; // Move right
        }
    }

    // Move the snake based on the current direction
    void Move()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);


    }

    private void snakePositioning()
    {
        Vector3 position = transform.position;

        if(position.x > xdirection)
        {
            position.x = -xdirection;
        }
        else if(position.x<-xdirection)
        {
            position.x = xdirection;
        }
        
        if(position.y > ydirection)
        {
            position.y = -ydirection;
        }
        else if (position.y < -ydirection)
        {
            position.y = ydirection;
        }

        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particle"))
        {
            gm.CollectParticle();
        }
    }

}
