using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int moveSpeed = 10;
    public Vector3 staringPosition;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Force);
    }

    public void On_Click_ChangerStarting_Position()
    {
        transform.position = staringPosition;
        gameObject.SetActive(false);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag($"WinArea"))
        {
            GameObject.Find("Level Manager").GetComponent<LevelComplete>().SuccessfullyCompleteLevel();
        }
        
        if (other.gameObject.CompareTag($"LostArea"))
        {
            GameObject.Find("Level Manager").GetComponent<LevelComplete>().LevelFailed();
        }
    }
}
