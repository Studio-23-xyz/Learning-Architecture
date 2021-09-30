using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    
    private RectTransform _rectTransform;
    
    [SerializeField] private GameObject parent;

    [SerializeField] private GameObject road;
    
    [SerializeField] private GameObject roadPrefab;

    
    [SerializeField] private GameObject _roadPrefabParent;

    private Camera _mainCamera;
    
    private GameObject _newRoad;
    
    private GameObject _newRoadPrefab;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //_roadPrefabParent = GameObject.Find("Road Parent");
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //_roadPrefabParent = GameObject.Find("Road Parent");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        _newRoad = Instantiate(road, parent.transform.position, road.transform.rotation, parent.transform);
        _rectTransform = _newRoad.GetComponent<RectTransform>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor * 1.2f;
        //_newRoad.transform.position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(_newRoad);
        _newRoadPrefab = Instantiate(roadPrefab, parent.transform.position, roadPrefab.transform.rotation, _roadPrefabParent.transform);
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        _newRoadPrefab.transform.position = mouseWorldPosition;
    }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     Debug.Log("OnPointerDown");
    // }
}
