using UnityEditor;
using UnityEngine;

namespace Utility.GameFlow
{
    public class MoveCameraTo : TriggerParent
    {
        [SerializeField] internal CameraManager cameraManager;
        [SerializeField] internal Vector3 target;
        [SerializeField] internal float time;
        [SerializeField] internal bool useTransform;
        [SerializeField] internal Transform targetTransform;
        [SerializeField] internal Vector3 offset;


        [SerializeField] internal bool lerp;
        private bool _rTriggerNull;

        private void Start()
        {
            _rTriggerNull = nextTrigger != null;

            if (cameraManager == null)
            {
                if (Camera.main != null) cameraManager = Camera.main.GetComponent<CameraManager>();
                Debug.LogWarning("Expensive Method");
            }
        }
        
        protected override void Command()
        {
            
            if (lerp)
            {
                cameraManager.MoveCameraToLerp(useTransform ? targetTransform.position + offset : target + offset, time);
            }
            else
            {
                cameraManager.MoveCameraToSmooth(useTransform ? targetTransform.position + offset : target + offset,
                    time);
            }

            if (_rTriggerNull)
            {
                nextTrigger.Trigger(delay);
            }
        }
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(MoveCameraTo))]
    public class MoveCameraToCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var t = (MoveCameraTo)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraManager"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("time"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("lerp"));
            EditorGUILayout.Space(10);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("useTransform"));

            if (t.useTransform)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("targetTransform"));
            }
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("target"));
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("offset"));
            EditorGUILayout.Space(10);
            
            
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