using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using TMPro;
using UnityEngine;

public class SendLevelNumberToCollector : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private NameScoreLevelCollector nameScoreLevelCollector;

    public void On_Click_GetAndSendLevelNumber()
    {
        nameScoreLevelCollector.level = levelNumber;
    }
}
