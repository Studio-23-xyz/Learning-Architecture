using LightShaft.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTubeLinkSender : MonoBehaviour
{
    public YoutubePlayer youtubePlayer;
    public string youtubeLink;

    public GameObject backgroundSound;

    private void Start()
    {
        youtubePlayer = GameObject.Find("FYoutubePlayer").GetComponent<YoutubePlayer>();

        backgroundSound = GameObject.Find("BGSound").transform.GetChild(0).gameObject;
    }

    [ContextMenu("PlayVideo")]
    public void On_Click_SendYoutubeLinkandPlayVideo()
    {
        youtubePlayer.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        youtubePlayer.Play(youtubeLink);

        backgroundSound.SetActive(false);
    }

  
}
