using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Point : MonoBehaviour
{
    public bool runtime = true;
    public List<Bar> connectedBars;
    public Vector2 pointID;
    public Rigidbody2D rbd;

    private void Start()
    {
        if (runtime == false)
        {
            rbd.bodyType = RigidbodyType2D.Static;
            pointID = transform.position;
            if (GameManager.AllPoints.ContainsKey(pointID) == false) GameManager.AllPoints.Add(pointID, this);
        }
    }

    void Update()
    {
        if (runtime == false)
        {
            if (transform.hasChanged == true)
            {
                transform.hasChanged = false;
                transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
    }
}
