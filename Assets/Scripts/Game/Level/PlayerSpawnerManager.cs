using Game.Overworld.Shop;
using UnityEngine;

namespace Game.Level
{
    public class PlayerSpawnerManager : MonoBehaviour
    {
        [SerializeField] private GameObject defaultPrefab;
        [SerializeField] private GameObject swordPrefab;
        [SerializeField] private GameObject gunPrefab;

        [SerializeField] private Transform spawnLocation;

        [HideInInspector] public GameObject player;


        public static PlayerSpawnerManager instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }

            instance = this;

        }

        private void OnEnable()
        {
            PlayerManager playerManager = PlayerManager.instance;
            if (playerManager.Data.hasGun)
            {
                player = Instantiate(gunPrefab, spawnLocation.position, new Quaternion());
                return;
            }

            if (playerManager.Data.hasSword)
            {
                player = Instantiate(swordPrefab, spawnLocation.position, new Quaternion());
                return;
            }

            player = Instantiate(defaultPrefab, spawnLocation.position, new Quaternion());
        }
    }
}