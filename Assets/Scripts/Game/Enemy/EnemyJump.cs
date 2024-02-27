using UnityEngine;

namespace Game.Enemy
{
    public class EnemyJump : JumpBase
    {
        [Space(20)]
        [SerializeField] private Transform left;
        [SerializeField] private Transform right;
        [SerializeField] private float jumpThreshold;

        protected override void Update()
        {
            if (grounded)
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

            base.Update();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (grounded)
            {
                if (other.gameObject.layer == 8)
                {
                    Jump();
                }
            }
        }
    }
}