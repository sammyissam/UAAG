using UnityEditor;
using UnityEngine;

namespace Utility.GameFlow
{
    public class TeleportGO : TriggerParent
    {
        [SerializeField] private GameObject objectToTeleport;
        [SerializeField] internal bool useTransform = true;

        [SerializeField] private Transform teleportPointTransform;
        [SerializeField] private Vector3 teleportPoint;
        

        protected override void Command()
        {
            objectToTeleport.transform.position = useTransform ? teleportPointTransform.position : teleportPoint;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(TeleportGO))]
    public class TeleportGOE : Editor
    {
        public override void OnInspectorGUI()
        {
            TeleportGO t = (TeleportGO)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("objectToTeleport"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("useTransform"));

            if (t.useTransform)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("teleportPointTransform"));
            }
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("teleportPoint"));
            }
            
            
            
            
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