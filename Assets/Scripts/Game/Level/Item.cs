using UnityEngine;

namespace Game.Level
{
    public abstract class Item : MonoBehaviour
    {

        public abstract void PickedUp(GameObject GO);
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 3)
            {
                PickedUp(gameObject);
                Destroy(gameObject);
            }
        }
    }
}