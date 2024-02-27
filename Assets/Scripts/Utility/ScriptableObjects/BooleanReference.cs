using UnityEngine;

namespace Utility.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BooleanReference", menuName = "ScriptableObjects/Boolean", order = 0)]
    public class BooleanReference :
        ScriptableObject
    {
        public bool b;
    }
}