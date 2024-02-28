using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Utility.GameFlow
{
   
    public class RelayTrigger : TriggerParent
    {
        [SerializeField] private UnityEvent onTrigger;
        
       
        protected override void Command()
        {
            onTrigger.Invoke();
        }
        
    }


    [CustomEditor(typeof(RelayTrigger))]
    public class RelayTriggerE : Editor
    {
        public override void OnInspectorGUI()
        {
            RelayTrigger t = (RelayTrigger)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("onTrigger"));
            
            EditorGUILayout.LabelField("Next Command");
            EditorGUILayout.BeginHorizontal();
            t.nextTrigger = (TriggerParent)EditorGUILayout.ObjectField(t.nextTrigger, typeof(TriggerParent), true);
            t.delay = EditorGUILayout.FloatField(t.delay);
            EditorGUILayout.EndHorizontal();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}