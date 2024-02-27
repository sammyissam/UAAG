using UnityEditor;
using UnityEngine;

namespace Utility.GameFlow
{
    public class ActivateComponent : TriggerParent
    {
        [SerializeField] private MonoBehaviour monoBehaviourToChange;
        [SerializeField] private bool state;
        
        protected override void Command()
        {
            monoBehaviourToChange.enabled = state;
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ActivateComponent))]
    public class ActivateComponentE : Editor
    {
        public override void OnInspectorGUI()
        {
            ActivateComponent t = (ActivateComponent)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("monoBehaviourToChange"));
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