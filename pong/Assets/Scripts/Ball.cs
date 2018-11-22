using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Balls default movement speed
    public float speed = 30;

    // The balls Rigidbody component
    private Rigidbody2D rigidBody;


    // Use this for initialization
    void Start()
    {
        // Get reference to the ball Rigidbody
        rigidBody = GetComponent<Rigidbody2D>();

        // When the ball is created move it to
        // the right (1,0) at the desired speed
        rigidBody.velocity = Vector2.right * speed;
    }

    // Called every time a ball collides with something
    // the object it hit is passed as a parameter
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            SoundManager.Instance.PlayOnShot(SoundManager.Instance.wallBloop);
        }
        else if (other.gameObject.CompareTag("Paddle"))
        {
            HandlePaddleHit(other, GetOrientationNumber(other));

            SoundManager.Instance.PlayOnShot(SoundManager.Instance.hitPaddleBloop);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            transform.position = new Vector2(0, 0);
            rigidBody.velocity = new Vector2(GetOrientationNumber(other), 0) * speed;

            SoundManager.Instance.PlayOnShot(SoundManager.Instance.goalBloop);
        }
    }

    void HandlePaddleHit(Collision2D other, int orientation)
    {
        // Find y for the ball vector based
        // on where the ball hit the paddle
        // Above the center y angles up
        // Below the center y angles down
        var y = BallHitPaddleWhere(transform.position, other.transform.position, other.collider.bounds.size.y);

        // Vector ball moves to
        // Go left or right on the x axis
        // depending on which panel was hit   
        var direction = new Vector2(orientation, y).normalized;

        // Change the velocity / direction of ball You assign a vector to velocity
        rigidBody.velocity = direction * speed;
    }

    int GetOrientationNumber(Collision2D other)
    {
        return other.gameObject.name.StartsWith("Left") ? 1 : -1;
    }

    // Find y for the ball vector based on where the ball hit the paddle
    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}