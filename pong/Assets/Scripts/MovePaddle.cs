using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public float speed = 30f;

    private void FixedUpdate()
    {
        var verticalPress = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalPress) * speed;
    }
}