using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    private bool _barCreationStarted = false;
    public Bar currentBar;
    public GameObject barToInstantiate;
    public Transform barParent;
    public Point currentStartPoint;
    public Point currentEndPoint;
    public GameObject pointToInstantiate;
    public Transform pointParent;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_barCreationStarted == false)
        {
            _barCreationStarted = true;
            StartBarCreation(Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(eventData.position)));
        }

        else
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                FinishBarCreation();
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                _barCreationStarted = false;
                DeleteCurrentBar();
            }
        }
    }

    private void DeleteCurrentBar()
    {
        Destroy(currentBar.gameObject);
         if (currentStartPoint.connectedBars.Count == 0 && currentStartPoint.runtime == true) Destroy(currentStartPoint.gameObject);
        if (currentEndPoint.connectedBars.Count == 0 && currentEndPoint.runtime == true) Destroy(currentEndPoint.gameObject);
        
        
    }

    private void FinishBarCreation()
    {
        if (GameManager.AllPoints.ContainsKey(currentEndPoint.transform.position))
        {
            Destroy(currentEndPoint.gameObject);
            currentEndPoint = GameManager.AllPoints[currentEndPoint.transform.position];
        }

        else
        {
            GameManager.AllPoints.Add(currentEndPoint.transform.position, currentEndPoint);
        }
        
        currentStartPoint.connectedBars.Add(currentBar);
        currentEndPoint.connectedBars.Add(currentBar);

        currentBar.startJoint.connectedBody = currentStartPoint.rbd;
        currentBar.startJoint.anchor = currentBar.transform.InverseTransformPoint(currentBar.startPosition);
        currentBar.endJoint.connectedBody = currentEndPoint.rbd;
        currentBar.endJoint.anchor = currentBar.transform.InverseTransformPoint(currentEndPoint.transform.position);
        
        StartBarCreation(currentEndPoint.transform.position);
    }

    void StartBarCreation(Vector2 startPosition)
    {
        currentBar = Instantiate(barToInstantiate, barParent).GetComponent<Bar>();
        currentBar.startPosition = startPosition;

        if (GameManager.AllPoints.ContainsKey(startPosition))
        {
            currentStartPoint = GameManager.AllPoints[startPosition];
        }

        else
        {
            currentStartPoint = Instantiate(pointToInstantiate, startPosition, quaternion.identity, pointParent)
                .GetComponent<Point>();
            GameManager.AllPoints.Add(startPosition, currentStartPoint);
        }
        
        currentEndPoint = Instantiate(pointToInstantiate, startPosition, Quaternion.identity, pointParent)
            .GetComponent<Point>();
    }

    private void Update()
    {
        if (_barCreationStarted == true)
        {
            Vector2 endPosition = (Vector2) Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector2 dir = endPosition - currentBar.startPosition;
            Vector2 clampedPosition = currentBar.startPosition + Vector2.ClampMagnitude(dir, currentBar.maxLength);

            currentEndPoint.transform.position = (Vector2) Vector2Int.FloorToInt(clampedPosition);
                
            currentEndPoint.pointID = currentEndPoint.transform.position;
            currentBar.UpdateCreatingBar(currentEndPoint.transform.position);
        }
    }
}
