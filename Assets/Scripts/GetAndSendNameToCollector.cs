using Scriptable_object;
using TMPro;
using UnityEngine;

public class GetAndSendNameToCollector : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private NameScoreLevelCollector nameScoreLevelCollector;

    public void On_click_GetAndSendName()
    {
        nameScoreLevelCollector.playerName = nameInputField.text;
    }
}
