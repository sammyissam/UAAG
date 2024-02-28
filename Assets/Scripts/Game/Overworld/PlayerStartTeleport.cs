using UnityEngine;

namespace Game.Overworld
{
    public class PlayerStartTeleport : MonoBehaviour
    {
        private void Start()
        {
            gameObject.transform.position = GameManager.instance.GetPositionToSpawn();
        }
    }
}