using UnityEngine;
using Utility;

namespace Game.Level.Player
{
    public class GiveMainCameraTransform : MonoBehaviour
    {
        private void Start()
        {
            Camera.main.GetComponent<CameraManager>().objectToTrack = transform;
        }
    }
}