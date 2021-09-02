using System.Collections.Generic;
using UnityEngine;

namespace Scriptable_object
{
    [CreateAssetMenu]
    public class LevelSaveAndLoad : ScriptableObject
    {
        // public List<Vector3> roadsPosition
        // {
        //     get
        //     {
        //         List<Vector3> data = new List<Vector3>();
        //
        //         foreach (var position in RawData.RoadPositions)
        //         {
        //             data.Add(new Vector3(position[0], position[1],position[2] ));
        //         }
        //
        //         return data;
        //     }
        // }

        public List<Vector3> connectorsPosition;

        public List<Vector3> supportPillarsPosition;
        
        public List<Vector3> roadsPosition;
        
        public List<Vector3> connectorsRotation;

        public List<Vector3> supportPillarsRotation;
        
        public List<Vector3> roadsRotation;

        public List<Vector3> allConnectorsPosition;
        
        
        
        
        

        public LevelSaveAndLoadRawData RawData;

        public void SaveAsJson()
        {
            
        }

        public void LoadJson()
        {
            
        }

    }

   
    
    public class LevelSaveAndLoadRawData
    {
        public List<float[]> RoadPositions;
        public List<float[]> ConnectorPositions;
        public List<float[]> SupportPillarPositions;
    }
    
}
