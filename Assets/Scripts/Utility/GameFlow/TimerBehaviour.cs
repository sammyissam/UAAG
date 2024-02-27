using UnityEngine;
using UnityEngine.Events;
using Utility.GameFlow;

namespace Utility
{
    public class TimerBehaviour : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private UnityEvent onTimerEnd;

        private Timer timer;
        private void Start()
        {
            timer = new Timer(duration);
            
            timer.OnTimerEnd += TimerOnOnTimerEnd;
        }

        private void TimerOnOnTimerEnd()
        {
            onTimerEnd.Invoke();

            Destroy(this);
        }

        private void Update()
        {
            timer.Tick(Time.deltaTime);
        }
    }
}