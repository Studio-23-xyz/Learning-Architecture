using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class CarSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip carSound;
    public AudioClip crashSound;
    public AudioClip winSound;

    public float shakeDuration;
    public float shakeStrength;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource.clip = carSound;
        audioSource.loop = true;
        audioSource.Play();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WinArea"))
        {
            audioSource.Stop();
            audioSource.clip = winSound;
            audioSource.loop = false;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("LostArea"))
        {
            audioSource.Stop();
            audioSource.clip = crashSound;
            audioSource.loop = false;
            audioSource.Play();

            Camera.main.DOShakePosition(shakeDuration, shakeStrength);
            Vibration.Vibrate(500);
        }
    }
}
