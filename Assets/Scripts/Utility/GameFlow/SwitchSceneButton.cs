using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;


namespace Utility.GameFlow
{
    public class SwitchSceneButton : MonoBehaviour
    {
        [SerializeField] internal int scene;
        [SerializeField] internal Button button;
        [SerializeField] internal bool quitGame;
        private int _sceneInt = int.MinValue;

        private void Start()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
                if (button == null)
                {
                    Debug.LogWarning("Button Could not be found");
                    Destroy(this);
                }
            }

            button.onClick.AddListener(ListenerButton);

            _sceneInt = scene;
        }

        void ListenerButton()
        {
            if (quitGame)
            {
#if UNITY_EDITOR
                if (Application.isEditor)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
#endif

                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(_sceneInt);
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(SwitchSceneButton))]
    public class SwitchSceneCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SwitchSceneButton switchSceneButton = (SwitchSceneButton)target;
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("button"));
            if (!switchSceneButton.quitGame)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("scene"));
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("quitGame"));
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}