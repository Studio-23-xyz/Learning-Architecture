using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GetChildFromParents : MonoBehaviour
{
    public List<GameObject> children;

    public GameObject ConnectorFinderGameObject;

    private ConnectorFinder connectorFinder;

    [FormerlySerializedAs("rood")] public bool road;

    public bool connectors;

    private void Start()
    {
        connectorFinder = ConnectorFinderGameObject.GetComponent<ConnectorFinder>();
    }

    [ContextMenu("GetChildren")]
    public void GetChildren()
    {
        children.Clear();
        connectorFinder.FindConnector();
       // children = new List<GameObject>(transform.childCount);

        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);


            if (road == true)
            {
                child.GetComponent<ConnectHingeJointWithConnector>().ActivatePhysicsAndHingeJointConnectorFinder();
            }

            if (connectors == true)
            {
                child.GetComponent<FindClosestConnector>().ConfigureHingeJoint();
            }
            //child.GetComponent<ConnectHingeJointWithConnector>().enabled = true;
            
        }
    }

    public void DisableConnectHingeJointWithConnectorComponent()
    {
        foreach (Transform child in transform)
        {
           //child.GetComponent<ConnectHingeJointWithConnector>().enabled = false;

           if (road == true)
           {
               child.GetComponent<ConnectHingeJointWithConnector>().SetRigidbodyToStatic();
           }

           if (connectors == true)
           {
               child.GetComponent<FindClosestConnector>().SetRigidbodyToStatic();
           }
           
           
        }
    }
    
    
    
}
