using UnityEditor;
using UnityEngine;

namespace Utility.GameFlow
{
    public class SetGOActive : TriggerParent
    {
        [SerializeField] private GameObject[] gameObjectToChange;
        [SerializeField] private bool state;
        
        protected override void Command()
        {
            foreach (GameObject g in gameObjectToChange)
            {
                g.SetActive(state);
            }
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(SetGOActive))]
    public class SetGOActiveE : Editor
    {
        public override void OnInspectorGUI()
        {
            SetGOActive t = (SetGOActive)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("gameObjectToChange"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("state"));
            
            EditorGUILayout.LabelField("Next Command");
            EditorGUILayout.BeginHorizontal();
            t.nextTrigger = (TriggerParent)EditorGUILayout.ObjectField(t.nextTrigger, typeof(TriggerParent), true);
            t.delay = EditorGUILayout.FloatField(t.delay);
            EditorGUILayout.EndHorizontal();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
}