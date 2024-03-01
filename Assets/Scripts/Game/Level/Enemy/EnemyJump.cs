using System;

namespace Game.Level.Enemy
{
    using UnityEngine;

    namespace Game.Level.Enemy
    {
        public class EnemyJump : JumpBase
        {
            [Space(20)] [SerializeField] private Transform left;
            [SerializeField] private Transform right;
            [SerializeField] private float jumpThreshold;
            [SerializeField] private LayerMask layerMask;
            private float countdown;

            private void Start()
            {
                countdown = 1;
            }

            internal void Update()
            {
                countdown -= Time.deltaTime;
                if (grounded)
                {
                    if (countdown < 0)
                    {
                        if (Physics2D.Raycast(left.position, Vector2.left, jumpThreshold, layerMask))
                        {
                            Jump();
                        }
                        else if (Physics2D.Raycast(right.position, Vector2.right, jumpThreshold, layerMask))
                        {
                            Jump();
                        }
                    }
                }
            }
        }
    }
}