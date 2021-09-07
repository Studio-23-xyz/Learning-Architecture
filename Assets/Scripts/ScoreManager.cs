using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    dreamloLeaderBoard dl;
    // Start is called before the first frame update
    void Start()
    {
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendScore()
    {
        //dl.AddScore(this.playerName, totalScore);
    }

    public void GetLeaderBoard()
    {
        List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();
    }

}
