using UnityEditor;
using UnityEngine;
using Utility.GameFlow;

namespace Game.UI
{
    public class FadeManager : MonoBehaviour
    {
        public static FadeManager instance;
        [SerializeField] private Animator animator;
        private static readonly int Out = Animator.StringToHash("FadeOut");
        private static readonly int In = Animator.StringToHash("FadeIn");


        [SerializeField] private TriggerParent disable;
        [SerializeField] private TriggerParent enable;
        

        private void Start()
        {
            if (instance != null)
            {
                Debug.LogWarning("Destroyed Extra FadeManager");
                Destroy(gameObject.transform.parent.gameObject);
                return;
            }

            instance = this;
        }


        public void FadeIn()
        {
            animator.SetTrigger(In);
            disable.Trigger(0.5f);
        }


            
        public void FadeOut()
        {
            enable.Trigger(0);
            animator.SetTrigger(Out);
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(FadeManager))]
    public class FadeManagerE : Editor
    {
        public override void OnInspectorGUI()
        {
            FadeManager t = (FadeManager)target;


            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("FadeIn"))
            {
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    t.FadeIn();
                }
#endif
            }
            if (GUILayout.Button("FadeOut"))
            {
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    t.FadeOut();
                }
#endif
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.PropertyField(serializedObject.FindProperty("animator"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("disable"));

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}