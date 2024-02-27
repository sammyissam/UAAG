using UnityEngine;

namespace Utility.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Int", menuName = "ScriptableObjects/Integer", order = 0)]
    public class IntReference : ScriptableObject
    {
        public int i;
    }
}