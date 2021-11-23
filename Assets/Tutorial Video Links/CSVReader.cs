using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    private void Awake()
    {
        ReadCsv();
    }

    [System.Serializable]
    public class LearningMaterial
    {
        public string name;
        public string link;
        public string type;
    }

    [System.Serializable]
    public class LearningMaterialList
    {
        public LearningMaterial[] learningMaterials;
    }

    public LearningMaterialList myLearningMaterialList = new LearningMaterialList();

    void ReadCsv()
    {
        string[] data = textAssetData.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);
        int tableSize = data.Length / 3 - 1;

        myLearningMaterialList.learningMaterials = new LearningMaterial[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myLearningMaterialList.learningMaterials[i] = new LearningMaterial();
            myLearningMaterialList.learningMaterials[i].name = data[3 * (i+1)];
            myLearningMaterialList.learningMaterials[i].link = data[3 * (i+1) + 1];
            myLearningMaterialList.learningMaterials[i].type = data[3 * (i+1) + 2];
        }
    }
}
