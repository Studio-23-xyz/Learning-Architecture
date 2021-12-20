using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonList : MonoBehaviour
{
    public GameObject buttonTemplate;

    public CSVReader csvReader;

    // Start is called before the first frame update
    void Start()
    {
        csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();


        for (int i=0; i < csvReader.myLearningMaterialList.learningMaterials.Length; i++)
        {
            var newCreatedButton = Instantiate(buttonTemplate, transform);
            newCreatedButton.transform.GetComponentInChildren<TMP_Text>().text = csvReader.myLearningMaterialList.learningMaterials[i].name;
            newCreatedButton.GetComponent<YouTubeLinkSender>().youtubeLink = csvReader.myLearningMaterialList.learningMaterials[i].link;

        }

    }

}
