using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using UnityEngine;

public class ShowLeaderBoardLevelWise : MonoBehaviour
{
    public int levelNumber;
    
    public NameScoreLevelCollector nameScoreLevelCollector;

    public LeaderBoard leaderBoard;
    // Start is called before the first frame update
    void Start()
    {
       leaderBoard = leaderBoard.GetComponent<LeaderBoard>();
    }

    public void ShowLeaderBoard()
    {
        nameScoreLevelCollector.level = levelNumber;
        
        leaderBoard.GetLeaderBoard();
    }
   
}
