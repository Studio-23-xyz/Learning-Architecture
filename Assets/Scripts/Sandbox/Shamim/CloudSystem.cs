using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSystem : MonoBehaviour
{
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject endPosition;
    [SerializeField] private GameObject clouds;

    [Range(1,10)]
    public int cloudMovmentSpeed;


    // Start is called before the first frame update
    void Start()
    {
        clouds.transform.position = startPosition.transform.position;
        StartCoroutine(MoveToStartPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveToEndPosition()
    {
        while (clouds.transform.position != endPosition.transform.position)
        {
            clouds.transform.position = Vector3.Lerp(startPosition.transform.position, endPosition.transform.position, cloudMovmentSpeed * Time.deltaTime);
            yield return StartCoroutine(MoveToStartPosition());
        }

        
        
    }

    IEnumerator MoveToStartPosition()
    {
        while (clouds.transform.position != startPosition.transform.position)
        {
            clouds.transform.position = Vector3.Lerp(endPosition.transform.position, startPosition.transform.position, cloudMovmentSpeed * Time.deltaTime);
            yield return StartCoroutine(MoveToEndPosition());
        }

       

    }
}
