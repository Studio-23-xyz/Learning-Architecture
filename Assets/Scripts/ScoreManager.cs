using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    dreamloLeaderBoard _dl;
    [SerializeField] private NameScoreLevelCollector nameScoreLevelCollector;

    private string _playerName;
    private int _totalScore;
    private int _levelNumber;
    
    void Start()
    {
        this._dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
    }
    
    public void On_Click_SendScore()
    {
        _playerName = nameScoreLevelCollector.playerName;
        _totalScore = nameScoreLevelCollector.score;
        _levelNumber = nameScoreLevelCollector.level;
        _dl.AddScore(this._playerName, _totalScore, _levelNumber);
    }

    public void GetLeaderBoard()
    {
        List<dreamloLeaderBoard.Score> scoreList = _dl.ToListHighToLow();
    }

}
