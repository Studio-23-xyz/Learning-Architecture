using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using TMPro;
using UnityEngine;

public class SendLevelNumberAndNameToCollector : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private NameScoreLevelCollector nameScoreLevelCollector;
    [SerializeField] private TMP_InputField nameInputField;

    public string levelNumberOnLevel;

    private void Awake()
    {
        levelNumberOnLevel = levelNumber.ToString();
    }

    public void On_Click_GetAndSendLevelNumber()
    {
        nameScoreLevelCollector.level = levelNumber;
    }
    
    public void On_Click_GetAndSendName()
    {
        nameScoreLevelCollector.playerName = nameInputField.text;
    }
}
