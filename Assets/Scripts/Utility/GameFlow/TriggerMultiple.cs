using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Utility.GameFlow
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerMultiple : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> triggerEnter;
        [SerializeField] public UnityEvent<GameObject> triggerExit;
        [SerializeField] private int layerMask;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (layerMask == other.gameObject.layer)
            {
                triggerEnter.Invoke(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (layerMask == other.gameObject.layer)
            {
                triggerExit.Invoke(other.gameObject);
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(TriggerMultiple))]
    public class TriggeredMultipleE : Editor
    {
        public override void OnInspectorGUI()
        {
            TriggerMultiple triggerOnce = (TriggerMultiple)target;
            if (GUILayout.Button("Command"))
            {
                if (Application.isPlaying)
                {
                    triggerOnce.triggerEnter.Invoke(null);
                }
            }

            base.OnInspectorGUI();
        }
    }
#endif
}