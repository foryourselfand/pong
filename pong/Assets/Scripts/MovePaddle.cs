using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public float speed = 30f;

    // Called each time the frame updates but this is used instead of update when using Rigidbody
    private void FixedUpdate()
    {
        // Check to see if keys associated with vertical movement is being pressed
        var verticalPress = Input.GetAxisRaw("Vertical");

        // Move the paddle in the y direction depending on the keys pressed and the desired speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalPress) * speed;
    }
}