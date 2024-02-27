using UnityEngine;

namespace Utility.GameFlow
{
    public class PlaySound : TriggerParent
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;
        private bool _aNotNull;

        private void Start()
        {
            _aNotNull = nextTrigger != null;
        }

        protected override void Command()
        {
            audioSource.PlayOneShot(audioClip, 1);

            if (_aNotNull)
            {
                nextTrigger.Trigger(delay);
            }
            
        }
    }
}