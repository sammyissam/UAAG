using UnityEditor;
using UnityEngine;

namespace Utility.GameFlow
{
    public class ChangeGOActive : TriggerParent
    {
        [SerializeField] private GameObject gameObjectToChange;
        [SerializeField] private bool state;
        
        protected override void Command()
        {
            gameObjectToChange.SetActive(state);
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ChangeGOActive))]
    public class ChangeGOActiveE : Editor
    {
        public override void OnInspectorGUI()
        {
            ChangeGOActive t = (ChangeGOActive)target;

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