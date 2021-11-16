using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioClip buttonSound;

    
    [ContextMenu("Play Sound")]
    public void ClickSound()
    {
        buttonClick.PlayOneShot(buttonSound);
    }

}
