using UnityEngine;
using UnityEngine.Serialization;
using Utility.UI;

namespace Utility
{
    public class CameraManager : Pauseable
    {
        [SerializeField] private bool movingSmooth;
        private bool movingLerp;
        private Vector3Smooth targetSmooth;
        private Vector3Lerp vector3Lerp;
        private bool _tracking = true;
        public Transform objectToTrack;
        [SerializeField] private Vector3 offsetWhileTracking;
        [SerializeField] private bool smooth = true;
        [SerializeField] private float distanceDelta = 5;

        
        public void SetTracking(bool tracking)
        {
            _tracking = tracking;
        }

        /// <summary>
        /// Moves the camera to a location over a duration of time
        /// </summary>
        /// <param name="position">Position to move the camera to</param>
        /// <param name="time">How long it should take in seconds to reach final destination</param>
        public void MoveCameraToSmooth(Vector3 position, float time = 1f)
        {
            targetSmooth = new Vector3Smooth(transform.position, position, time);
            movingSmooth = true;
        }

        public void MoveCameraToLerp(Vector3 position, float time = 1f)
        {
            vector3Lerp = new Vector3Lerp(transform.position, position, time);
            movingLerp = true;
        }

        private void Update()
        {
            if (_tracking)
            {
                if (smooth)
                {
                    var target = objectToTrack.position;
                    var current = transform.position;
                    transform.position = Vector3.Lerp(current, target + offsetWhileTracking, distanceDelta * Time.deltaTime);
                }
                else
                {
                    transform.position = objectToTrack.position + offsetWhileTracking;
                }
            }
            else if (movingSmooth)
            {
                MoveSmooth();
            }
            else if(movingLerp)
            {
                MoveLerp();
            }
        }


        void MoveSmooth()
        {
            transform.position = targetSmooth.Tick(transform.position, Time.deltaTime);
            if (targetSmooth._timerEnd)
            {
                targetSmooth = null;
                movingSmooth = false;
            }
        }

        void MoveLerp()
        {
            transform.position = vector3Lerp.Tick(Time.deltaTime);
            if (transform.position == vector3Lerp.target)
            {
                movingLerp = false;
                vector3Lerp = null;
            }
        }
    }
}