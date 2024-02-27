using UnityEngine;

namespace Game.Movement
{
    class PlayerJump : JumpBase
    {
        [Space(20)] [SerializeField] public int maxJumps;
        private int _jumpsLeft;
        private bool _jumpAllowed;
        private float timer;
        [SerializeField] private float cooldown;

        [SerializeField] private bool jumpActive;

        private void OnEnable()
        {
            onGroundedChanged.AddListener(GroundChanged);
        }

        private void OnDisable()
        {
            onGroundedChanged.RemoveListener(GroundChanged);
        }

        private void GroundChanged(bool isGrounded)
        {
            if (isGrounded)
                _jumpsLeft = maxJumps;
        }

        protected override void Update()
        {
            UpdateA();
            base.Update();
        }

        public void SetJumpActive(bool isJumpActive)
        {
            jumpActive = isJumpActive;
        }

        void UpdateA()
        {
            timer -= Time.deltaTime;

            if (timer > 0)
            {
                return;
            }

            if (Input.GetAxis("Jump") == 0)
            {
                return;
            }

            if (_jumpsLeft < 1) return;
            
            if(!jumpActive) return;

            _jumpsLeft -= 1;
            timer = cooldown;
            Jump();
        }
    }
}