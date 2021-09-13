using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public int totalCost;
    private TMP_Text _totalCostTextField;
    public NameScoreLevelCollector nameScoreLevelCollector;


    private void Start()
    {
        _totalCostTextField = GameObject.Find("Total Cost Text").GetComponent<TMP_Text>();
    }


    public void SumOfTotalCost(int cost)
    {
        totalCost += cost;
        _totalCostTextField.text = totalCost.ToString() + " $";
    }

    public void SendTotalScore()
    {
        nameScoreLevelCollector.score = totalCost;
    }
    
    public void DecreaseCost(int cost)
    {
        totalCost -= cost;
        _totalCostTextField.text = totalCost.ToString() + " $";
    }
}
