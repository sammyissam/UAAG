using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utility.GameFlow
{
    public abstract class TriggerParent : MonoBehaviour
    {

        [SerializeField] internal TriggerParent nextTrigger;
        [SerializeField] internal float delay;
        private bool _istriggerParentNotNull;

        private void Start()
        {
            _istriggerParentNotNull = nextTrigger != null;
        }

        public void Trigger()
        {
            Command();

            if (_istriggerParentNotNull)
            {
                nextTrigger.Trigger(delay);
            }
            
        }

        public void Trigger(float delay)
        {
            StartCoroutine(TriggerDelayed(delay));
        }

        protected abstract void Command();
        

        private IEnumerator TriggerDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);

            Command();
            
            if (_istriggerParentNotNull)
            {
                nextTrigger.Trigger(delay);
            }
        }
        
        // EditorGUILayout.LabelField("Next Command");
        // EditorGUILayout.BeginHorizontal();
        // t.triggerA = (TriggerA)EditorGUILayout.ObjectField(t.triggerA, typeof(TriggerA), true);
        // t.delay = EditorGUILayout.FloatField(t.delay);
        // EditorGUILayout.EndHorizontal();
        
    }
}