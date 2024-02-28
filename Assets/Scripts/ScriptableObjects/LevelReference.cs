using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelReference", menuName = "ScriptableObjects/Level", order = 0)]
    public class LevelReference : ScriptableObject
    {
        public string levelName;
        public Vector3 positionToSpawn;
    }
}