using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightShaft.Scripts;

public class VideoBackButton : MonoBehaviour
{
    public YoutubePlayer youtubePlayer;
    public GameObject backgroundSound;

    private void Start()
    {
        backgroundSound = GameObject.Find("BGSound").transform.GetChild(0).gameObject;
    }

    public void On_Click_SendYoutubeLinkandPlayVideo()
    {
        youtubePlayer.Stop();
        backgroundSound.SetActive(true);
    }
}
