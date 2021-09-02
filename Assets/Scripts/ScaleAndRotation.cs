using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotation : MonoBehaviour
{
    [SerializeField] private float scaleAmount;

    private Vector3 _tempLocalScale;

    private Vector3 _tempRotation;

    public float rotationAmount;

    private Button _scaleButton;

    private Button _rotateButton;

    [SerializeField] private MaterialCost materialCost;

    //[SerializeField] private HingeJoint2D _hingeJoint2D;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_hingeJoint2D.connectedAnchor);
        
    }

    [ContextMenu("IncreaseScale")]
    public void IncreaseScale()
    {
        _tempLocalScale = transform.localScale;
        _tempLocalScale.x += scaleAmount;
        transform.localScale = _tempLocalScale;
        materialCost.CostAddToTheMainBudget();
    }

    [ContextMenu("Rotate")]
    public void Rotate()
    {
        _tempRotation = transform.eulerAngles;
        _tempRotation.z += rotationAmount;
        transform.eulerAngles = _tempRotation;

    }

    private void OnMouseUpAsButton()
    {
        _scaleButton = GameObject.Find("ScaleButton").GetComponent<Button>();
        _scaleButton.onClick.RemoveAllListeners();
        _scaleButton.onClick.AddListener(() => IncreaseScale());
        
        _rotateButton = GameObject.Find("RotateButton").GetComponent<Button>();
        _rotateButton.onClick.RemoveAllListeners();
        _rotateButton.onClick.AddListener(() => Rotate());
    }
}
