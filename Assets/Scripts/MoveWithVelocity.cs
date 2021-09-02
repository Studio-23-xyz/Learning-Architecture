using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithVelocity : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
