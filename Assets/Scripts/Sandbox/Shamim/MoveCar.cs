using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int moveSpeed = 10;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Force);
    }
}
