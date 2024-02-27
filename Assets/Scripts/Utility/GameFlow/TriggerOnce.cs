using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Utility.GameFlow
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerOnce : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> triggerEnter;
        [SerializeField] public UnityEvent<GameObject> triggerExit;
        [SerializeField] private int layerMask;
        private bool triggered;
        private bool triggeredExit;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (layerMask == other.gameObject.layer)
            {
                if (!triggered)
                {
                    triggerEnter.Invoke(other.gameObject);
                    triggered = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (layerMask == other.gameObject.layer)
            {
                if (!triggeredExit)
                {
                    triggerExit.Invoke(other.gameObject);
                    triggeredExit = true;
                }
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(TriggerOnce))]
    public class TriggerCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            TriggerOnce triggerOnce = (TriggerOnce)target;
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