using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utility.GameFlow
{
    public class TriggerButton : MonoBehaviour
    {
        [SerializeField] private TriggerParent nextTrigger;

        internal void Command()
        {
            nextTrigger.Trigger();
        }
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(TriggerButton))]
    public class UIButtonE : Editor
    {
        public override void OnInspectorGUI()
        {
            TriggerButton t = (TriggerButton)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("nextTrigger"));

            if (GUILayout.Button("TriggerOnce"))
            {
                t.Command();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
}