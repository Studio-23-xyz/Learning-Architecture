using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public int totalCost;
    public TMP_Text totalCostTextField;

    public void SumOfTotalCost(int cost)
    {
        totalCost += cost;
        totalCostTextField.text = totalCost.ToString() + " $";
    }
}
