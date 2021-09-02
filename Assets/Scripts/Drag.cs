using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private Vector2 _initialPositionMouse;
    private Vector2 _initialPositionObject;
    public bool isDragged;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            transform.position = _initialPositionObject + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) -
                                 _initialPositionMouse;
        }
    }

    private void OnMouseEnter()
    {
        _initialPositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _initialPositionObject = transform.position;
        isDragged = true;
    }
    
    
    
}
