using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectHingeJointWithConnector : MonoBehaviour
{
    public ConnectorFinder connectorFinder;

    public HingeJoint2D leftHingeJoint;
    
    public HingeJoint2D rightHingeJoint;

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     ActivatePhysicsAndHingeJointConnectorFinder();
    // }

   
    // Update is called once per frame
    
    // private void OnDisable()
    // {
    //     rb.bodyType = RigidbodyType2D.Static;
    // }

    // private void OnEnable()
    // {
    //     rb.bodyType = RigidbodyType2D.Dynamic;
    //     ActivatePhysicsAndHingeJointConnectorFinder();
    // }

    [ContextMenu("Null detect")]
    public void CheckNullCanDetectOrNot()
    {
        if (leftHingeJoint == null)
        {
            leftHingeJoint = gameObject.AddComponent<HingeJoint2D>();
            leftHingeJoint.anchor = new Vector2(-0.5f, 0f);
            leftHingeJoint.breakForce = 100;
        }
        
        if (rightHingeJoint == null)
        {
            rightHingeJoint = gameObject.AddComponent<HingeJoint2D>();
            rightHingeJoint.anchor = new Vector2(0.5f, 0f);
            rightHingeJoint.breakForce = 100;
        }
    }


    public void SetRigidbodyToStatic()
    {
        rb.bodyType = RigidbodyType2D.Static;
        CheckNullCanDetectOrNot();
        
        connectorFinder = GameObject.Find("ConnectorFinder").GetComponent<ConnectorFinder>();
        
       

        foreach (var _conncetor in connectorFinder.connector)
        {
            _conncetor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            // if ((Vector2) _conncetor.transform.position == leftHingeJoint.connectedAnchor)
            // {
            //     leftHingeJoint.connectedBody = _conncetor.GetComponent<Rigidbody2D>();
            // }
            // else
            // {
            //     Debug.Log("left Joint not Found");
            // }
            
            leftHingeJoint.connectedBody = null;

            // if ((Vector2) _conncetor.transform.position == rightHingeJoint.connectedAnchor)
            // {
            //     rightHingeJoint.connectedBody = _conncetor.GetComponent<Rigidbody2D>();
            // }
            //
            // else
            // {
            //     Debug.Log("Right Joint not Found");
            // }

            rightHingeJoint.connectedBody = null;
        }
    }
    
    public void ActivatePhysicsAndHingeJointConnectorFinder()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;

        connectorFinder = GameObject.Find("ConnectorFinder").GetComponent<ConnectorFinder>();
        
        foreach (var _conncetor in connectorFinder.staticConnector)
        {
            //_conncetor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if ((Vector2) _conncetor.transform.position == leftHingeJoint.connectedAnchor)
            {
                leftHingeJoint.connectedBody = _conncetor.GetComponent<Rigidbody2D>();
            }
            else
            {
                Debug.Log("left Joint not Found");
            }

            if ((Vector2) _conncetor.transform.position == rightHingeJoint.connectedAnchor)
            {
                rightHingeJoint.connectedBody = _conncetor.GetComponent<Rigidbody2D>();
            }

            else
            {
                Debug.Log("Right Joint not Found");
            }
        }

        foreach (var _conncetor in connectorFinder.connector)
        {
            _conncetor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if ((Vector2) _conncetor.transform.position == leftHingeJoint.connectedAnchor)
            {
                leftHingeJoint.connectedBody = _conncetor.GetComponent<Rigidbody2D>();
            }
            else
            {
                Debug.Log("left Joint not Found");
            }

            if ((Vector2) _conncetor.transform.position == rightHingeJoint.connectedAnchor)
            {
                rightHingeJoint.connectedBody = _conncetor.GetComponent<Rigidbody2D>();
            }

            else
            {
                Debug.Log("Right Joint not Found");
            }
        }
        
        
    }

}
