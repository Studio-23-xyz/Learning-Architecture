using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : MonoBehaviour
{
    
    private GetChildFromParents _roadParent;
    private GetChildFromParents _connectorParent;
    private Button _editButton;
    private SaveAndLoadManager _saveAndLoadManager;
    // Start is called before the first frame update
    void Start()
    {
        _roadParent = GameObject.Find("Road Parent").GetComponent<GetChildFromParents>();
        _connectorParent = GameObject.Find("Connector Parent").GetComponent<GetChildFromParents>();
        _saveAndLoadManager = GameObject.Find("Save and Load Manager").GetComponent<SaveAndLoadManager>();
        _editButton = gameObject.GetComponent<Button>();
        Edit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Edit()
    {
        _editButton.onClick.AddListener(_roadParent.DisableConnectHingeJointWithConnectorComponent);
        _editButton.onClick.AddListener(_connectorParent.DisableConnectHingeJointWithConnectorComponent);
        _editButton.onClick.AddListener(_saveAndLoadManager.RestoreData);
    }
}
