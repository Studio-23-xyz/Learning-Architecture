using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewController : MonoBehaviour
{
    public NameList nameList;
    public GameObject PlayerNamePrefab;
    public Transform PlayerNameParent;

    private GameObject _tempName;

    void Start()
    {
        foreach (string name in nameList.names)
        {
            _tempName = Instantiate(PlayerNamePrefab, transform.position, transform.rotation, PlayerNameParent);
            _tempName.transform.GetChild(0).GetComponent<TMP_Text>().text = name;
        }

    }
}
