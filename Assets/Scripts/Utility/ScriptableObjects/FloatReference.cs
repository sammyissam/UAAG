using UnityEngine;

namespace Utility.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Float", menuName = "ScriptableObjects/Float", order = 0)]
    public class FloatReference : ScriptableObject
    {
        public float f;
    }
}