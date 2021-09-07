using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scriptable_object
{ 
[CreateAssetMenu]
public class NameScoreLevelCollector : ScriptableObject
{
    public string playerName;
    public int score;
    public int level;
}
}
