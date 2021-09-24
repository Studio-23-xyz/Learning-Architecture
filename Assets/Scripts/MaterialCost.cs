using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCost : MonoBehaviour
{
    [SerializeField] private int cost;

    private CostManager _costManager;

    private GameObject _costManagerGameObject;
   
    void Start()
    {
        _costManagerGameObject = GameObject.Find("CostManager");
        _costManager = (CostManager)_costManagerGameObject.GetComponent("CostManager");
        CostAddToTheMainBudget();
    }
    
    public void CostAddToTheMainBudget()
    {
        _costManager.SumOfTotalCost(cost);
        
    }
    
    public void CostDecreaseToTheMainBudget()
    {
        _costManager.DecreaseCost(cost);
        
    }
    
    public void CostDecreaseToTheMainBudget(int scaled)
    {
        _costManager.DecreaseCost(cost * scaled);
    }
    
    
}
