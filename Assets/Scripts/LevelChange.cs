using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public int sceneIndexNumber;
    
    public void On_Click_LevelChange()
    {
        SceneManager.LoadScene(sceneIndexNumber);
    }
}
