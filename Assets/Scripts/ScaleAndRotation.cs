using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotation : MonoBehaviour
{
    

    private Vector3 _tempLocalScale;

    private Vector3 _tempRotation;

    public float rotationAmount;

    private Button _scaleButton;

    private Button _rotateButton;

    private Button _deleteButton;

    private int _remainingScale;

    private ModificatorOnOff _modificatorOnOff;

    private TMP_Text _remainingScaleText;

    [SerializeField] private MaterialCost materialCost;
    [SerializeField] private float scaleAmount;
    [SerializeField] private float minLength;
    [SerializeField] private float maxLength;
    [SerializeField] private int scaled = 1;
    [SerializeField] private int maxScale;
    

    private void Start()
    {
        _modificatorOnOff = GameObject.Find("ModificatorOnOff").GetComponent<ModificatorOnOff>();
        ActivateModificationFunctionalityForThisGameObject();

    }

    [ContextMenu("IncreaseScale")]
    public void IncreaseScale()
    {
        if (transform.localScale.x < maxLength)
        {
            _tempLocalScale = transform.localScale;
            _tempLocalScale.x += scaleAmount;
            transform.localScale = _tempLocalScale;
            materialCost.CostAddToTheMainBudget();
            scaled++;
            RemainingScale();
        }
    }
    
    public void DecreaseScale()
    {
        if (transform.localScale.x > minLength)
        {
            _tempLocalScale = transform.localScale;
            _tempLocalScale.x -= scaleAmount;
            transform.localScale = _tempLocalScale;
            materialCost.CostDecreaseToTheMainBudget();
            scaled--;
            RemainingScale();
        }
    }

    [ContextMenu("Rotate")]
    public void Rotate()
    {
        _tempRotation = transform.eulerAngles;
        _tempRotation.z += rotationAmount;
        transform.eulerAngles = _tempRotation;
    }

    public void Delete()
    {
        
        materialCost.CostDecreaseToTheMainBudget(scaled);
        _modificatorOnOff.InActiveModificatorUI();
        Destroy(gameObject);
    }

    private void OnMouseUpAsButton()
    {
        ActivateModificationFunctionalityForThisGameObject();
    }

    private void ActivateModificationFunctionalityForThisGameObject()
    {
        _modificatorOnOff.HighlightingGameObject(gameObject);
        _remainingScaleText = GameObject.Find("Remaining Scale").GetComponent<TMP_Text>();
        RemainingScale();

        _scaleButton = GameObject.Find("IncreaseButton").GetComponent<Button>();
        _scaleButton.onClick.RemoveAllListeners();
        _scaleButton.onClick.AddListener(() => IncreaseScale());

        _scaleButton = GameObject.Find("DecreaseButton").GetComponent<Button>();
        _scaleButton.onClick.RemoveAllListeners();
        _scaleButton.onClick.AddListener(() => DecreaseScale());

        _rotateButton = GameObject.Find("RotateButton").GetComponent<Button>();
        _rotateButton.onClick.RemoveAllListeners();
        _rotateButton.onClick.AddListener(() => Rotate());

        _deleteButton = GameObject.Find("DeleteButton").GetComponent<Button>();
        _deleteButton.onClick.RemoveAllListeners();
        _deleteButton.onClick.AddListener(Delete);
    }

    private void RemainingScale()
    {
        _remainingScale = maxScale - scaled;
        _remainingScaleText.text = "scale: " + _remainingScale;
    }
}
