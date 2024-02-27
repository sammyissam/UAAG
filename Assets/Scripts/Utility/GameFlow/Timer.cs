using System;

namespace Utility.GameFlow
{
    public class Timer
    {
        public Timer(float remainingTime)
        {
            RemainingTime = remainingTime;
            InitialTime = remainingTime;
        }


        public event Action OnTimerEnd;

        public float InitialTime { get; private set; }
        public float RemainingTime { get; private set; }

        public float RemainingTimeNormalized => (InitialTime - RemainingTime) / InitialTime;

        public void Tick(float deltaTime)
        {
            if(RemainingTime <= 0f){ return; }
            RemainingTime -= deltaTime;
            CheckForTimerEnd();
        }

        private void CheckForTimerEnd()
        {
            if (RemainingTime > 0f) return;

            RemainingTime = 0f; 
            
            OnTimerEnd?.Invoke();
        }
    }
}