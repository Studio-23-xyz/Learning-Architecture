using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //public GameObject successUI;
    public ModalWindowManager failUI;
    public GameObject nameInputField;
    public GameObject leaderBoard;
    public ModalWindowManager successUI;

    private void Start()
    {
        successUI = GameObject.Find("Success UI").GetComponent<ModalWindowManager>();
        failUI = GameObject.Find("Fail UI").GetComponent<ModalWindowManager>();
        leaderBoard = GameObject.Find("Leader Board");
        nameInputField = GameObject.Find("Name Input Field");
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
        leaderBoard.transform.GetChild(0).gameObject.SetActive(true);
        leaderBoard.GetComponent<LeaderBoard>().GetLeaderBoard();
    }
    
    public void GoToMainMenu(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
