using UnityEngine;

namespace Utility.UI
{
    public class OnUnpause : MonoBehaviour
    {
        [SerializeField] private bool state;
        private void Awake()
        {
            StateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
        }

        private void OnDestroy()
        {
            StateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
        }
        
        private void OnPauseStateChanged(PauseState pauseState)
        {
            if (pauseState == PauseState.Running)
            {
                gameObject.SetActive(state);
            }
        }
    }
}