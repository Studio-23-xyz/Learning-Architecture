using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using UnityEngine;

public class ShowLeaderBoardLevelWise : MonoBehaviour
{
    public string levelNumber;
    
    public NameScoreLevelCollector nameScoreLevelCollector;

    public PlayfabManager playfabManager;
    // Start is called before the first frame update
    void Start()
    {
        playfabManager = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();
    }

    public void ShowLeaderBoard()
    {
        //nameScoreLevelCollector.level = levelNumber;

        playfabManager.GetLeaderBoard(levelNumber);
        Debug.Log(levelNumber);
    }
   
}
