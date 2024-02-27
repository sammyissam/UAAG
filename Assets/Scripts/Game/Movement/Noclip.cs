using UnityEngine;
using Utility.UI;

namespace Game.Movement
{
    public class Noclip : Pauseable
    {
        private bool noclip;
        [SerializeField] private float speed = 20;
        [SerializeField] private MonoBehaviour[] behaviours;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SetNoclip(!noclip);
            }

            if (noclip)
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                var position = transform.position;

                position = new Vector3(position.x + x * speed * Time.deltaTime, position.y + y * speed * Time.deltaTime,
                    position.z);

                transform.position = position;
            }
        }

        void SetNoclip(bool isNocliping)
        {
            noclip = isNocliping;

            foreach (MonoBehaviour behaviour in behaviours)
            {
                behaviour.enabled = !noclip;
            }
        }
    }
}