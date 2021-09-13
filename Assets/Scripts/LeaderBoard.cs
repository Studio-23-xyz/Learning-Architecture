using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.PackageManager.UI;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    dreamloLeaderBoard _dl;
    public GameObject PlayerNamePrefab;
    public Transform PlayerNameParent;
    public List<dreamloLeaderBoard.Score> scoreList;
    public GameObject leaderBoardGameObject;
    
    private GameObject _tempName;
    private dreamloLeaderBoard leaderBoardObject;

    private void OnEnable()
    {
        leaderBoardObject =leaderBoardGameObject.GetComponent<dreamloLeaderBoard>();
        leaderBoardObject.GetScores();
    }

    void Start()
    {
        this._dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
    }
        
    [ContextMenu("Get Leader Board")]
    public void GetLeaderBoard()
    {
        
        
        //_dl.AddScore("Empty", 0);
        scoreList = leaderBoardObject.ToListHighToLow();


        // while (scoreList == null)
        // {
        //     Debug.Log("Loading");
        // }
        Debug.Log( scoreList.Count);
        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            _tempName = Instantiate(PlayerNamePrefab, transform.position, transform.rotation, PlayerNameParent);
            _tempName.transform.GetChild(0).GetComponent<TMP_Text>().text = currentScore.playerName + "  "+ currentScore.score;
        }
    }

    private void Update()
    {
        // if (_dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
        // if (_dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");

        // //if (scoreList == null || scoreList.Count == 0)
        // //{
        //     //for (int i = 0; i < 10; i++)
        //     //{
        //         Debug.Log("Loading");
        //         _dl.AddScore("Empty", 0);
        //         scoreList = _dl.ToListHighToLow();
        //    // }
        //     
        // //}
        // //else
        // //{
        //     Debug.Log( scoreList.Count);
        // //}
        
        
        
    }
}
