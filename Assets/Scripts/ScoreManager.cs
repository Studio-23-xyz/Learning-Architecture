using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    dreamloLeaderBoard _dl;
    [SerializeField] private NameScoreLevelCollector nameScoreLevelCollector;

    public TMP_InputField nameInputField;
    public LeaderboardData leaderboardData;
    public string levelNumber;
    
 
    private string _playerName;
    private int _totalScore;
    private int _levelNumber;
    private PlayfabManager _playfabManager;
    
    void Start()
    {
        this._dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        _playfabManager = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();
    }
    
    public void On_Click_SendScore()
    {
        // _playerName = nameScoreLevelCollector.playerName;
        // _totalScore = nameScoreLevelCollector.score;
        // _levelNumber = nameScoreLevelCollector.level;
        // _dl.AddScore(this._playerName, _totalScore, _levelNumber);
        
        _playfabManager.SendLeaderBoard(leaderboardData.cost, leaderboardData.levelNumber);
        _playfabManager.ChangeDisplayName(leaderboardData.name);
        
        Debug.Log("Data Is Sent");
    }

    public void SetLevelData()
    {
        leaderboardData.name = nameInputField.text;
        leaderboardData.cost = nameScoreLevelCollector.score;
        leaderboardData.levelNumber = levelNumber;
    }

    public void GetLeaderBoard()
    {
        List<dreamloLeaderBoard.Score> scoreList = _dl.ToListHighToLow();
    }

}
