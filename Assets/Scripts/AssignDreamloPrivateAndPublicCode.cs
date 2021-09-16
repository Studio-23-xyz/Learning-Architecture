using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignDreamloPrivateAndPublicCode : MonoBehaviour
{
    private dreamloLeaderBoard _dreamloLeaderBoard;
    private void Awake()
    {
        _dreamloLeaderBoard = gameObject.GetComponent<dreamloLeaderBoard>();
    }
    
    void Start()
    {
        _dreamloLeaderBoard.privateCode = "eoAskW8jaEa6_QjZg-aDAA14W4JVlT70i6Z98hZWM7Eg";
        _dreamloLeaderBoard.publicCode = "6136f1a98f40bb6e98cfdc2e";
    }
}
