using UnityEngine;

namespace Game.Level.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private GameObject goldPrefab;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            //Player layer = 3;
            if (other.gameObject.layer == 3)
            {
                Instantiate(goldPrefab, transform.position, new Quaternion());
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}