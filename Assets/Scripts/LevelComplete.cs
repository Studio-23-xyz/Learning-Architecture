using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //public GameObject successUI;
     ModalWindowManager failUI;
     GameObject nameInputField;
     GameObject leaderBoard;
     ModalWindowManager successUI;
     private PlayfabManager _playfabManager;

     public LeaderboardData leaderboardData;

    private void Start()
    {
        successUI = GameObject.Find("Success UI").GetComponent<ModalWindowManager>();
        failUI = GameObject.Find("Fail UI").GetComponent<ModalWindowManager>();
        leaderBoard = GameObject.Find("Leader Board");
        nameInputField = GameObject.Find("Name Input Field");
        _playfabManager = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();
    }
    
    [ContextMenu("Rotate")]
    public void SuccessfullyCompleteLevel()
    {
        successUI.AnimateWindow();
        successUI.windowTitle.text = "Congratulations";
        successUI.windowDescription.text = "You have completed this Level";
    }
    
    public void LevelFailed()
    {
        failUI.AnimateWindow();
        failUI.windowTitle.text = "Sorry";
        failUI.windowDescription.text = "Please, Try Again";
    }

    public void ShowNameField()
    {
        nameInputField.transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void ShowLeaderBoard()
    {
        _playfabManager.GetLeaderBoard(leaderboardData.levelNumber);
    }
    
    public void GoToMainMenu(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
    