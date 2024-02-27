using UnityEngine;

namespace Game.Item
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private GameObject particleEffect;
        private protected abstract void Pickup();
        
        private protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            Pickup();
            Instantiate(particleEffect, transform.position, particleEffect.transform.rotation);
            Destroy(gameObject);
        }
    }
}