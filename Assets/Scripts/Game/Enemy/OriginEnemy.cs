using System.Collections;
using UnityEngine;
using Utility;
using Utility.ScriptableObjects;
using Utility.UI;

namespace Game.Enemy
{
    public class OriginEnemy : Pauseable
    {
        [SerializeField] private FloatReference speed;
        [SerializeField] private Transform player;

        [SerializeField] private float leaveDistance;
        [SerializeField] private float followDistance;
        
        private Vector3 _origin;
        private Camera _mainCamera;

        private SpriteRenderer _renderer;
        private EnemyJump _enemyJump;

        // 0 = idle
        // 1 = moving towards player
        // 2 = moving to origin
        [SerializeField] private int state = 0;

        private void Start()
        {
            _enemyJump = GetComponent<EnemyJump>();
            // _origin = transform.position;
            _mainCamera = Camera.main;

            _renderer = GetComponent<SpriteRenderer>();

            StartCoroutine(Origin());
        }

        private IEnumerator Origin()
        {
            while (!_enemyJump.grounded)
            {
                yield return null;
            }

            _origin = transform.position;
        }


        private void Update()
        {
            float playerDistance = Vector3.Distance(gameObject.transform.position, player.position);
            float originDistance = Vector3.Distance(_origin, transform.position);
            
            //Start walking to origin if player is too far away
            if (playerDistance > leaveDistance)
            {
                state = 2;
            }
            //start walking to origin if it gets too far from origin
            else if (originDistance > 25)
            {
                state = 2;
            }

            //If its walking to origin or its stationary
            if (state is 0 or 2)
            {
                //If Origin is within 15 Unity
                if (originDistance < 15)
                {
                    // If Player is within 10 unity
                    if (playerDistance < followDistance)
                    {
                        //start following player
                        state = 1;
                    }
                }
            }

            //if its walking to origin
            if (state == 2)
            {
                //If its walking to origin and it arrives, stop walking to origin
                if (originDistance < 0.5f)
                {
                    state = 0;
                }

                //If While walking to origin, it goes off screen And the origin is off screen. Teleport to origin
                if (!_renderer.isVisible && !Util.PointVisible(_mainCamera, _origin))
                {
                    transform.position = _origin;
                }
            }


            switch (state)
            {
                case 1:
                    Move(player.position);
                    break;
                case 2:
                    Move(_origin);
                    break;
            }
        }

        private void Move(Vector3 goal)
        {
            float x;
            x = Time.deltaTime;

            Vector3 playersPosition = goal - gameObject.transform.position;
            playersPosition.Normalize();

            if (playersPosition.x < 0)
            {
                x *= -1;
            }
            else
            {
                x *= 1;
            }

            //I dont know why we use Vars here but my IDE recommends it so i trust it 
            var transform1 = transform;
            var vector3 = transform1.position;

            vector3.x += x * speed.f;
            transform1.position = vector3;
        }
    }
}