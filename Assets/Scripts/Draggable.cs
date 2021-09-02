using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool _isDragged = false;
    private Vector3 _mouseDragStartPosition;
    private Vector3 _spriteDragStartPosition;
    private Vector3 _tempPosition;
    private Vector3 _tempPosition2;
    [SerializeField] private Vector3 clamp;

    private void OnMouseDown()
    {
        _isDragged = true;
        _mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _spriteDragStartPosition = transform.localPosition;
        Debug.Log("Mouse is Pressed");
    }

    private void OnMouseDrag() 
    {
        if (_isDragged)
        {
            //transform.localPosition =  _spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _mouseDragStartPosition);

            _tempPosition = _spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _mouseDragStartPosition);

            _tempPosition2 = Vector3Int.RoundToInt(_tempPosition);
            transform.position = _tempPosition2 + clamp ;


        }
    }

    private void OnMouseUp()
    {
        _isDragged = false;
    }
}
