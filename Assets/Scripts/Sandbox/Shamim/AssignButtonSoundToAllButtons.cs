using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AssignButtonSoundToAllButtons : MonoBehaviour
{
    public ButtonSound buttonSound;
    Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = (Button[])GameObject.FindObjectsOfType(typeof(Button));
        
        foreach(var button in buttons)
        {
            button.onClick.AddListener(buttonSound.ClickSound);
            button.onClick.AddListener(GetAllButtons);
        }
    }

    public void GetAllButtons()
    {
        buttons = (Button[])GameObject.FindObjectsOfType(typeof(Button));
    }

}
