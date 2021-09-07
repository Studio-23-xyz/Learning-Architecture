using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public int totalCost;
    public TMP_Text totalCostTextField;
    public NameScoreLevelCollector nameScoreLevelCollector;
  

    public void SumOfTotalCost(int cost)
    {
        totalCost += cost;
        totalCostTextField.text = totalCost.ToString() + " $";
    }

    public void SendTotalScore()
    {
        nameScoreLevelCollector.score = totalCost;
    }
}
