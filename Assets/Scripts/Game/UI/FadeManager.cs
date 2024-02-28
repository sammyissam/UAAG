using UnityEditor;
using UnityEngine;

namespace Game.UI
{
    public class FadeManager : MonoBehaviour
    {
        public static FadeManager instance;
        [SerializeField] private Animator animator;
        private static readonly int Out = Animator.StringToHash("FadeOut");
        private static readonly int In = Animator.StringToHash("FadeIn");

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
        }


        public void FadeOut()
        {
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

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}