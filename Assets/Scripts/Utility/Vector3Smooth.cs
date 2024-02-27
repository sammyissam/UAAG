using UnityEngine;
using Utility.GameFlow;

namespace Utility
{
    public class Vector3Smooth
    {
        private Timer _timer;
        private Vector3 _current;
        public Vector3 target;
        public bool _timerEnd;

        private Vector3 _velocity;

        public float stopwatch;

        
        public Vector3Smooth(Vector3 current, Vector3 target, float time)
        {
            _current = current;
            this.target = target;
            this.target += Vector3.one * 0.25f;
            _timer = new Timer(time);
            _timer.OnTimerEnd += TimerOnOnTimerEnd;
        }

        private void TimerOnOnTimerEnd()
        {
            _timerEnd = true;
        }
        
        public Vector3 Tick(Vector3 current,float timeDeltaTime)
        {
            if (_timerEnd)
            {
                return target;
            }
            _timer.Tick(timeDeltaTime);
            Vector3 smoothDamp = Vector3.SmoothDamp(current, target, ref _velocity,  1 / (timeDeltaTime * _timer.InitialTime) * timeDeltaTime, 100000, timeDeltaTime);
            stopwatch += timeDeltaTime;
            return smoothDamp;
        }
    }
}