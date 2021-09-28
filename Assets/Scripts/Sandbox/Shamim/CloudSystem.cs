using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloudSystem : MonoBehaviour
{
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject endPosition;
    [SerializeField] private GameObject clouds;

    [Range(.01f,100.0f)]
    public float cloudMovementSpeed;
    
    void Start()
    {
       clouds.transform.position = startPosition.transform.position;
       GoToEndPosition();
    }
    
    void GoToEndPosition()
    {
        clouds.transform.DOMove(endPosition.transform.localPosition, cloudMovementSpeed).SetLoops(-1,LoopType.Yoyo);
    }
}
