using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels", order = 0)]
    public class Levels : ScriptableObject
    {
        public LevelReference[] levelReferences;

    }
}