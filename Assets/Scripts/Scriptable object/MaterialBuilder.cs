using UnityEngine;

namespace Scriptable_object
{
    [CreateAssetMenu]
    public class MaterialBuilder : ScriptableObject
    {
        public string materialName;
        public float length;
        public Sprite materialSprite;
        public int materialStrength;
        public int materialCost;
        public int materialAngle;
    }
}
