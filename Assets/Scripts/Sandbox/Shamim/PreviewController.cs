using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewController : MonoBehaviour
{
    public NameList nameList;
    public TMP_Text PlayerNamePrefab;
    public Transform PlayerNameParent;

    private TMP_Text _tempName;

    void Start()
    {
        foreach (string name in nameList.names)
        {
            _tempName = Instantiate(PlayerNamePrefab, transform.position, transform.rotation, PlayerNameParent);
            _tempName.text = name;
        }

    }
}
