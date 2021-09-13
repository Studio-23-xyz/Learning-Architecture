using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private GetChildFromParents _roadParent;
    private GetChildFromParents _connectorParent;
    private SaveAndLoadManager _saveAndLoadManager;
    private CostManager _costManager;
    private SendLevelNumberAndNameToCollector _sendLevelNumberAndNameToCollector;
    private Button _playButton;
    
    
    void Start()
    {
        _roadParent = GameObject.Find("Road Parent").GetComponent<GetChildFromParents>();
        _connectorParent = GameObject.Find("Connector Parent").GetComponent<GetChildFromParents>();
        _saveAndLoadManager = GameObject.Find("Save and Load Manager").GetComponent<SaveAndLoadManager>();
        _costManager = GameObject.Find("CostManager").GetComponent<CostManager>();
        _sendLevelNumberAndNameToCollector =
            GameObject.Find("Level Manager").GetComponent<SendLevelNumberAndNameToCollector>();
        _playButton = gameObject.GetComponent<Button>();
        
        Simulate();

    }

    public void Simulate()
    {
        _playButton.onClick.AddListener(_roadParent.GetChildren);
        _playButton.onClick.AddListener(_connectorParent.GetChildren);
        _playButton.onClick.AddListener(_saveAndLoadManager.SaveData);
        _playButton.onClick.AddListener(_costManager.SendTotalScore);
        _playButton.onClick.AddListener(_sendLevelNumberAndNameToCollector.On_Click_GetAndSendLevelNumber);
    }
}
