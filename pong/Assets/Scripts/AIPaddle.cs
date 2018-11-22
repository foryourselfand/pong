using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    // Reference to the ball
    public Ball theBall;

    public float speed = 30;

    // lerp is used to smooth out movement over time
    public float lerpTweak = 2f;

    // Reference to the Rackets Rigidbody component
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        // Get reference to the attached Rigidbody
        // component
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Check if the ball y position is > racket y position
        var dir = new Vector2(0, theBall.transform.position.y > transform.position.y ? 1 : -1);

        // Lerp receives 2 vectors and smoothes the movement over time
        rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed, lerpTweak * Time.deltaTime);
    }
}