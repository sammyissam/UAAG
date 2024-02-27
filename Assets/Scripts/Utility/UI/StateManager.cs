namespace Utility.UI
{
    public class StateManager
    {
        public static StateManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StateManager();
                return _instance;
            }
        }

        private static StateManager _instance;

        public delegate void PauseStateChanged(PauseState pauseState);

        public event PauseStateChanged OnPauseStateChanged;

        public void ChangeState(PauseState pauseState)
        {
            CurrentState = pauseState;
            OnPauseStateChanged?.Invoke(pauseState);
        }

        public PauseState CurrentState { get; private set; }
    }

    public enum PauseState
    {
        Running,
        Paused
    }
}