using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayPause : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    [ContextMenu("Test Gameplay")]
    public void Play()
    {
        Time.timeScale = 1;
    }
}
