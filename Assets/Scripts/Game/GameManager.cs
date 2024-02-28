using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private Dictionary<string, Vector3> _levelReferencesDictionary;
        [SerializeField] private Levels levels;

        [SerializeField] private string lastLevel;

        private void Start()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            _levelReferencesDictionary = new Dictionary<string, Vector3>();

            foreach (LevelReference l in levels.levelReferences)
            {
                _levelReferencesDictionary.Add(l.levelName.ToLower(), l.positionToSpawn);
            }
        }

        public Vector3 GetPositionToSpawn()
        {
            try
            {
                return _levelReferencesDictionary[lastLevel.ToLower()];
            }
            catch (KeyNotFoundException)
            {
                return Vector3.zero;
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameManager))]
    public class GameManagerE : Editor
    {
        public override void OnInspectorGUI()
        {
            GameManager t = (GameManager)target;


            EditorGUILayout.PropertyField(serializedObject.FindProperty("levels"));


            // var currentState = GUI.enabled;
            // GUI.enabled = false;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("lastLevel"));
            // GUI.enabled = currentState;


            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}