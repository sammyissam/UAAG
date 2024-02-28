using UnityEditor;
using UnityEngine;
using Utility.UI;

namespace Game.Level.Movement
{
    public class Knockback : Pauseable
    {
        [SerializeField] private Vector2 currentVelocity;
        [SerializeField] private float knockBackForce = 10f;
        [SerializeField] private PlayerJump playerJump;

        [SerializeField] private Vector2 knockback = new(20, 20);
        [SerializeField] private LayerMask enemyLayerMask;
        
        [SerializeField] private float tValue;
        
        
        #region Start

        private void Start()
        {
            currentVelocity = new Vector2();
        }

        private void OnEnable()
        {
            playerJump.onGroundedChanged.AddListener(OnGroundedChanged);
            playerJump.hitCeiling.AddListener(HitCeiling);
        }


        private void OnDisable()
        {
            playerJump.onGroundedChanged.RemoveListener(OnGroundedChanged);
            playerJump.hitCeiling.RemoveListener(HitCeiling);
        }

        private void HitCeiling()
        {
            if (currentVelocity.magnitude > 0 && currentVelocity.magnitude < knockback.magnitude * 0.95f)
            {
                currentVelocity = Vector2.zero;
            }
        }

        #endregion

        private void OnGroundedChanged(bool arg0)
        {
            //if jump didnt just start
            if (arg0 && currentVelocity.magnitude > 0 && currentVelocity.magnitude < knockback.magnitude * 0.95f)
            {
                currentVelocity = Vector2.zero;
            }
        }

        private void Update()
        {
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, tValue * Time.deltaTime);

            if (currentVelocity.magnitude < 0.2f)
            {
                playerJump.SetJumpActive(true);
                currentVelocity = Vector2.zero;
            }
            
            var position = transform.position;
            Vector3 target = new Vector3(position.x + currentVelocity.x, position.y + currentVelocity.y, position.z);
            position = Vector3.MoveTowards(position, target, knockBackForce * Time.deltaTime);
            transform.position = position;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 7)
            {
                Vector3 playersPosition = other.gameObject.transform.position - gameObject.transform.position;
                playersPosition.Normalize();

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (playersPosition.x >= 0.1f)
                {
                    TriggerKnockback(true);
                }
                else
                {
                    TriggerKnockback(false);
                }
            }

            if (other.gameObject.layer == 6)
            {
                currentVelocity = Vector2.zero;
            }
            
        }

        public void TriggerKnockback(bool invert)
        {
            if (invert)
            {
                currentVelocity = knockback * new Vector2(-1, 1);
            }
            else
            {
                currentVelocity = knockback;
            }

            playerJump.SetGrounded(false);
            playerJump.SetJumpActive(false);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Knockback))]
    public class KnockbackE : Editor
    {
        public override void OnInspectorGUI()
        {
            Knockback t = (Knockback)target;


            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("KB left"))
            {
                t.TriggerKnockback(true);
            }

            if (GUILayout.Button("KB Right"))
            {
                t.TriggerKnockback(false);
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("currentVelocity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("knockBackForce"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("playerJump"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("knockback"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyLayerMask"));
            
            EditorGUILayout.Space(20);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("tValue"));
           
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}