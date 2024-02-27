using UnityEditor;
using UnityEngine;

namespace Utility.GameFlow
{
    public class Relay : TriggerParent
    {
        [SerializeField] private TriggerParent[] triggers;
        
        protected override void Command()
        {
            foreach (TriggerParent a in triggers)
            {
                a.Trigger();
            }
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(Relay))]
    public class TriggerAE : Editor
    {
        public override void OnInspectorGUI()
        {
            TriggerParent t = (TriggerParent)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("triggers"));
            
            // EditorGUILayout.LabelField("Next Command");
            // EditorGUILayout.BeginHorizontal();
            // t.triggerA = (TriggerA)EditorGUILayout.ObjectField(t.triggerA, typeof(TriggerA), true);
            // t.delay = EditorGUILayout.FloatField(t.delay);
            // EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
}