using UnityEngine;

namespace Utility.UI
{
    public class PauseStateBehaviour : MonoBehaviour
    {
        private void Start()
        {
            StateManager.Instance.ChangeState(PauseState.Running);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StateManager.Instance.ChangeState(StateManager.Instance.CurrentState == PauseState.Paused ? PauseState.Running : PauseState.Paused);
            }
        }



        public void Pause()
        {
         StateManager.Instance.ChangeState(PauseState.Paused);   
        }
        public void UnPause()
        {
            StateManager.Instance.ChangeState(PauseState.Running);   
        }
    }
}