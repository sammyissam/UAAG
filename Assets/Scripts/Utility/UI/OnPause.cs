using System;
using UnityEngine;

namespace Utility.UI
{
    public class OnPause : MonoBehaviour
    {
        [SerializeField] private bool state;
        private void Awake()
        {
            StateManager.Instance.OnPauseStateChanged += OnPauseStateChange;
        }


        private void OnDestroy()
        {
            StateManager.Instance.OnPauseStateChanged -= OnPauseStateChange;
        }

        private void OnPauseStateChange(PauseState pauseState)
        {
            if (pauseState == PauseState.Paused)
            {
                gameObject.SetActive(state);
            }
        }
    }
}