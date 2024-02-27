using UnityEngine;

namespace Utility.UI
{
    public abstract class Pauseable : MonoBehaviour
    {
        protected virtual void Awake()
        {
            StateManager.Instance.OnPauseStateChanged += OnPauseState;
        }

        protected virtual void OnDestroy()
        {
            StateManager.Instance.OnPauseStateChanged -= OnPauseState;
        }

        private void OnPauseState(PauseState pauseState)
        {
            enabled = pauseState == PauseState.Running;
        }
    }
}