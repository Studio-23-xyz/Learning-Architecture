using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevelNumber : MonoBehaviour
{
    private SendLevelNumberAndNameToCollector levelNumber;

    public TMP_Text levelNumberOnLevel;
    
    void Awake()
    {
        levelNumber = GameObject.Find("Level Manager").GetComponent<SendLevelNumberAndNameToCollector>();
    }

    private void Start()
    {
        levelNumberOnLevel.text = "Level " + levelNumber.levelNumberOnLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
