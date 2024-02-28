using UnityEngine;

namespace Game.UI
{
    public class FadeOnStart : MonoBehaviour
    {
        private void Start()
        {
            FadeManager.instance.FadeIn();
        }
    }
}