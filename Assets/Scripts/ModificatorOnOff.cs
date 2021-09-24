using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModificatorOnOff : MonoBehaviour
{

    public GameObject[] highlightingGameObjects;

    public GameObject playButton;
    public GameObject deleteButton;
    public GameObject increaseButton;
    public GameObject decreaseButton;
    public GameObject rotateButton;
    public GameObject scale;
    // Start is called before the first frame update
    void Start()
    {
        highlightingGameObjects = new GameObject[2];
        InActiveModificatorUI();
    }

    public void InActiveModificatorUI()
    {
        //playButton.SetActive(false);
        deleteButton.SetActive(false);
        increaseButton.SetActive(false);
        decreaseButton.SetActive(false);
        rotateButton.SetActive(false);
        scale.SetActive(false);
    }

    public void HighlightingGameObject(GameObject lastTouchedGameObject)
    {

        if (lastTouchedGameObject != highlightingGameObjects[0])
        {
            if (highlightingGameObjects[0] == null)
            {
                highlightingGameObjects[0] = lastTouchedGameObject;
                var last = highlightingGameObjects[0];
                last.transform.GetChild(1).gameObject.SetActive(true);
                //playButton.SetActive(true);
                deleteButton.SetActive(true);
                increaseButton.SetActive(true);
                decreaseButton.SetActive(true);
                rotateButton.SetActive(true);
                scale.SetActive(true);

                // if (lastTouchedGameObject.tag != "SupportPillar")
                // {
                //     rotateButton.SetActive(false);
                // }
            }

            else
            {
                if (highlightingGameObjects[1] != lastTouchedGameObject)
                {
                    highlightingGameObjects[1] = lastTouchedGameObject;
                    var last = highlightingGameObjects[1];
                    last.transform.GetChild(1).gameObject.SetActive(true);
                    highlightingGameObjects[0].transform.GetChild(1).gameObject.SetActive(false);
                    highlightingGameObjects[0] = last;
                }
            

            }
        }
        
    }
}
