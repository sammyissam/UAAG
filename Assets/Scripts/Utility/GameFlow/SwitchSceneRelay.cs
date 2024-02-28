using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility.GameFlow
{
    public class SwitchSceneRelay : TriggerParent
    {
        [SerializeField] private string sceneToGoTo;
        protected override void Command()
        {
            SceneManager.LoadScene(sceneToGoTo);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(SwitchSceneRelay))]
    public class SwitchSceneRelayE : Editor
    {
        public override void OnInspectorGUI()
        {
            SwitchSceneRelay t = (SwitchSceneRelay)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("sceneToGoTo"));
            
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