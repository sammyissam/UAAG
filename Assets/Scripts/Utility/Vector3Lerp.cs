using UnityEngine;
using Utility.GameFlow;

namespace Utility
{
    public class Vector3Lerp
    {
        private Timer _timer;
        private Vector3 _current;
        public Vector3 target;
        private bool _timerEnd;

        /// <summary>
        /// Lerps a Vector3 automatically over a period of time
        /// </summary>
        /// <param name="current">Current Vector3</param>
        /// <param name="target">Target Vector3</param>
        /// <param name="time">Time in seconds for current to get to target</param>
        public Vector3Lerp(Vector3 current, Vector3 target, float time)
        {
            _current = current;
            this.target = target;
            _timer = new Timer(time);
            _timer.OnTimerEnd += TimerOnOnTimerEnd;
        }

        private void TimerOnOnTimerEnd()
        {
            _timerEnd = true;
        }

        /// <summary>
        /// Ticks the instance of the lerp by amount of time
        /// </summary>
        /// <param name="timeDeltaTime">Time.DeltaTime</param>
        /// <returns></returns>
        public Vector3 Tick(float timeDeltaTime)
        {
            if (_timerEnd)
            {
                return target;
            }
            _timer.Tick(timeDeltaTime);
            return Vector3.Lerp(_current, target, _timer.RemainingTimeNormalized);
        }
    }
}