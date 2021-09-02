using System.Collections.Generic;
using Scriptable_object;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public GameObject roadParent;
    public GameObject connectorParent;
    public GameObject supportPillarParent;

    public LevelSaveAndLoad levelSaveAndLoad;

    public GameObject[] allConnectors;


    [ContextMenu("Save Data")]
    public void SaveData()
    {
        levelSaveAndLoad.roadsPosition.Clear();
        levelSaveAndLoad.connectorsPosition.Clear();
        levelSaveAndLoad.supportPillarsPosition.Clear();
        
        levelSaveAndLoad.roadsRotation.Clear();
        levelSaveAndLoad.connectorsRotation.Clear();
        levelSaveAndLoad.supportPillarsRotation.Clear();
        
        levelSaveAndLoad.allConnectorsPosition.Clear();

        allConnectors = GameObject.FindGameObjectsWithTag("Connector");
        
        foreach (Transform child in roadParent.transform)
        {
            levelSaveAndLoad.roadsPosition.Add(child.gameObject.transform.position);
            var eulerAngles = child.gameObject.transform.eulerAngles;
            levelSaveAndLoad.roadsRotation.Add(new Vector3(eulerAngles.x, eulerAngles.y,eulerAngles.z));
        }
        
        foreach (Transform child in connectorParent.transform)
        {
            levelSaveAndLoad.connectorsPosition.Add(child.gameObject.transform.position);
            var eulerAngles = child.gameObject.transform.eulerAngles;
            levelSaveAndLoad.connectorsRotation.Add(new Vector3(eulerAngles.x, eulerAngles.y,eulerAngles.z));
        }
        
        foreach (Transform child in supportPillarParent.transform)
        {
            levelSaveAndLoad.supportPillarsPosition.Add(child.gameObject.transform.position);
            var eulerAngles = child.gameObject.transform.eulerAngles;
            levelSaveAndLoad.supportPillarsRotation.Add(new Vector3(eulerAngles.x, eulerAngles.y,eulerAngles.z));
        }

        foreach (GameObject connector in allConnectors)
        {
            levelSaveAndLoad.allConnectorsPosition.Add(connector.transform.localPosition);
        }
    }

    [ContextMenu("Restore Data")]
    public void RestoreData()
    {
        int _roadCount = 0;
        foreach (Transform child in roadParent.transform)
        {
            child.position = levelSaveAndLoad.roadsPosition[_roadCount];
            child.eulerAngles = levelSaveAndLoad.roadsRotation[_roadCount];

            _roadCount++;
        }
        
        int _connectorCount = 0;
        foreach (Transform child in connectorParent.transform)
        {
            child.position = levelSaveAndLoad.connectorsPosition[_connectorCount];
            child.eulerAngles = levelSaveAndLoad.connectorsRotation[_connectorCount];
            
            _connectorCount++;
        }
        
        int _supportPillarCount = 0;
        foreach (Transform child in supportPillarParent.transform)
        {
            child.position = levelSaveAndLoad.supportPillarsPosition[_supportPillarCount];
            child.eulerAngles = levelSaveAndLoad.supportPillarsRotation[_supportPillarCount];
            _supportPillarCount++;
        }

        int _connectorPointCount = 0;

        foreach (GameObject connector in allConnectors)
        {
            connector.transform.localPosition = levelSaveAndLoad.allConnectorsPosition[_connectorPointCount];

            _connectorPointCount++;
        }
    }
    
    
    
    
}
