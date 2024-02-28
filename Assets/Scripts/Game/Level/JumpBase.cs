using System;
using UnityEngine;
using UnityEngine.Events;
using Utility.UI;

namespace Game.Level
{
    public class JumpBase : Pauseable
    {
        [SerializeField] private Transform down;
        [SerializeField] private Transform up;
        [SerializeField] private float floorDistance = 0.02f;
        [SerializeField] private protected LayerMask layerMask;


        public bool grounded { get; private set; }
        [SerializeField] internal float downwardsVelocity;

        [Header("Jump Physics")] [SerializeField]
        private float mass = 5.5f;

        [SerializeField] private float jumpMagnitude = 0.24f;
        [SerializeField] private float maxVelocity = -3f;


        [HideInInspector] [Space(10)] public UnityEvent<bool> onGroundedChanged;
        [HideInInspector] public UnityEvent jumped;
        [HideInInspector] public UnityEvent hitCeiling;


        internal float max;

        protected virtual void Update()
        {
            if (downwardsVelocity < maxVelocity)
            {
                downwardsVelocity = maxVelocity;
            }

            var transform1 = transform;
            var vector3 = transform1.position;
            vector3.y += downwardsVelocity;
            transform1.position = vector3;

            GroundedCheck();
            CeilingCheck();
        }

        private protected virtual void Jump()
        {
            if (CeilingRaycast())
            {
                return;
            }

            jumped.Invoke();
            downwardsVelocity = jumpMagnitude;
            SetGrounded(false);
        }

        public void SetGrounded(bool isGrounded)
        {
            if (grounded != isGrounded)
            {
                grounded = isGrounded;
                onGroundedChanged.Invoke(isGrounded);
            }
        }

        //Gravity in fixed update because it probably should be
        private void FixedUpdate()
        {
            if (!grounded)
            {
                downwardsVelocity += mass * -0.0981f * Time.deltaTime;
            }
        }

        internal virtual void GroundedCheck()
        {
            var position = down.position;

            max = floorDistance;

            // Extend distance check for ground depending on how fast your going
            if (downwardsVelocity < -0.1f)
            {
                max += (downwardsVelocity * -1) * 2;
            }

            //If ground detecting underneath player
            if (Physics2D.Raycast(position, Vector3.down, max, layerMask))
            {
                downwardsVelocity = 0f;
                SetGrounded(true);
            }
            else
            {
                SetGrounded(false);
            }
        }

        void CeilingCheck()
        {
            //If ceiling above player
            if (CeilingRaycast())
            {
                //Preventing Sticking to ceiling
                if (downwardsVelocity > 0f)
                {
                    downwardsVelocity = 0f;
                    hitCeiling.Invoke();
                }
            }
        }

        bool CeilingRaycast()
        {
            return Physics2D.Raycast(up.position, Vector2.up, floorDistance, layerMask);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            foreach (ContactPoint2D contact in other.contacts)
            {

                float y = transform.position.y - 1f;
                Debug.Log("transform.position.y = " + transform.position.y);
                Debug.Log("y = " + y);
                if (contact.point.y < y)
                {
                    Debug.Log(contact.point.y + "SDA" + y);
                }
                print(contact.collider.name + " hit " + contact.otherCollider.name);
                // Visualize the contact point
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
        }
    }
}