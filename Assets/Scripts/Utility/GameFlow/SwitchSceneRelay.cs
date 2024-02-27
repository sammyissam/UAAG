using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SwitchSceneRelay : MonoBehaviour
    {
        public void SwitchScene(int i)
        {
            SceneManager.LoadScene(i);
        }
        
    }
}