using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorFinder : MonoBehaviour
{
    public GameObject[] connector;

    public GameObject[] staticConnector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindConnector()
    {
        connector = GameObject.FindGameObjectsWithTag("Connector");
        staticConnector = GameObject.FindGameObjectsWithTag("Static Connector");
    }
}
