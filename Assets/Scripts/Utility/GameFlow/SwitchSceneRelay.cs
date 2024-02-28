using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility.GameFlow
{
    public class SwitchSceneRelay : MonoBehaviour
    {
        public void SwitchScene(int i)
        {
            SceneManager.LoadScene(i);
        }

        public void SwitchScene(string s)
        {
            SceneManager.LoadScene(s);
        }
        
    }
}