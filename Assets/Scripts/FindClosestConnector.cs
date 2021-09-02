using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestConnector : MonoBehaviour
{
    [SerializeField] private ConnectorFinder connectorFinder;
    [SerializeField] private float minDistance = 100;
    [SerializeField] private GameObject nearestConnector;
    [SerializeField] private GameObject connector01;
    [SerializeField] private GameObject connector02;
    [SerializeField] private HingeJoint2D hingeJoint01;
    [SerializeField] private HingeJoint2D hingeJoint02;
    [SerializeField] private Rigidbody2D rb;

    public HingeJoint2D[]  hingeJoint2Ds;
    
    [ContextMenu("Find The Closest Connector")]
    public void ConfigureHingeJoint()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        connectorFinder = GameObject.Find("ConnectorFinder").GetComponent<ConnectorFinder>();
        FindTheClosestConnector(connector01, hingeJoint01);
        FindTheClosestConnector(connector02, hingeJoint02);
    }

    
    public void CheckNullCanDetectOrNot()
    {
        if (hingeJoint01 == null)
        {
            hingeJoint01 = gameObject.AddComponent<HingeJoint2D>();
            hingeJoint01.anchor = new Vector2(-0.5f, 0f);
            hingeJoint01.breakForce = 100;
        }
        
        if (hingeJoint02 == null)
        {
            hingeJoint02 = gameObject.AddComponent<HingeJoint2D>();
            hingeJoint02.anchor = new Vector2(0.5f, 0f);
            hingeJoint02.breakForce = 100;
        }

        hingeJoint2Ds = GetComponents<HingeJoint2D>();
        
        hingeJoint2Ds[0].anchor = new Vector2(-0.5f, 0f);
        hingeJoint2Ds[1].anchor = new Vector2(0.5f, 0f);
    }
    public void SetRigidbodyToStatic()
    {
        rb.bodyType = RigidbodyType2D.Static;
        CheckNullCanDetectOrNot();

        connectorFinder = GameObject.Find("ConnectorFinder").GetComponent<ConnectorFinder>();
        foreach (var _connector in connectorFinder.connector)
        {
            _connector.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            hingeJoint01.connectedBody = null;
            hingeJoint02.connectedBody = null;
        }
    }

    void FindTheClosestConnector(GameObject _connector, HingeJoint2D _hingeJoint)
    {
        minDistance = 100f;
        
        foreach (GameObject connector in connectorFinder.connector)
        {
            if (connector != connector01 &&  connector != connector02)
            {
                float distance = Vector3.Distance(_connector.transform.position, connector.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestConnector = connector.transform.parent.gameObject;
                }
            }
        }
        
        foreach (GameObject connector in connectorFinder.staticConnector)
        {
            if (connector != connector01 &&  connector != connector02)
            {
                float distance = Vector3.Distance(_connector.transform.position, connector.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestConnector = connector;
                }
            }
        }
        _hingeJoint.connectedBody = nearestConnector.GetComponent<Rigidbody2D>();
    }
}
