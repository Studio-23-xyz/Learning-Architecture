using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    
    private RectTransform _rectTransform;
    
    [SerializeField] private GameObject parent;

    [SerializeField] private GameObject road;
    
    [SerializeField] private GameObject roadPrefab;

    [SerializeField] private GameObject roadPrefabParent;

    [SerializeField] private Camera mainCamera;
    
    private GameObject _newRoad;
    
    private GameObject _newRoadPrefab;

    
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        _newRoad = Instantiate(road, parent.transform.position, road.transform.rotation, parent.transform);
        _rectTransform = _newRoad.GetComponent<RectTransform>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Debug.Log("drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(_newRoad);
        _newRoadPrefab = Instantiate(roadPrefab, parent.transform.position, roadPrefab.transform.rotation, roadPrefabParent.transform);
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        _newRoadPrefab.transform.position = mouseWorldPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
