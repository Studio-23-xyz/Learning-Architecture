using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
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
    public NameScoreLevelCollector nameScoreLevelCollector;
    
    private GameObject _tempName;
    private dreamloLeaderBoard leaderBoardObject;
    private DateTime _dateTime;

    private void OnEnable()
    {
        leaderBoardGameObject = GameObject.Find("dreamloPrefab");
        leaderBoardObject = leaderBoardGameObject.GetComponent<dreamloLeaderBoard>();
        leaderBoardObject.GetScores();
    }

    void Start()
    {
        _dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
    }
        
    [ContextMenu("Get Leader Board")]
    public void GetLeaderBoard()
    {
        int _rankNumber = 1;
        
        foreach (Transform child in PlayerNameParent.transform) 
        {
            Destroy(child.gameObject);
        }
        //_dl.AddScore("Empty", 0);
        scoreList = leaderBoardObject.ToListLowToHigh();


        // while (scoreList == null)
        // {
        //     Debug.Log("Loading");
        // }
        Debug.Log( scoreList.Count);
        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            
            if (currentScore.seconds == nameScoreLevelCollector.level)
            {
                var isValidDate = DateTime.TryParse(currentScore.dateString, out _dateTime);
                
                _tempName = Instantiate(PlayerNamePrefab, transform.position, transform.rotation, PlayerNameParent);
                _tempName.transform.GetChild(0).GetComponent<TMP_Text>().text = _rankNumber.ToString();
                _tempName.transform.GetChild(1).GetComponent<TMP_Text>().text = currentScore.playerName;
                _tempName.transform.GetChild(2).GetComponent<TMP_Text>().text = currentScore.score.ToString();
                _tempName.transform.GetChild(3).GetComponent<TMP_Text>().text = _dateTime.ToString("MM/dd/yyyy");
                _rankNumber++;
            }
            
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
