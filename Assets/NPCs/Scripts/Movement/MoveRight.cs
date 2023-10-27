using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace NPCs.Scripts.Movement
{
    public class MoveRight : MonoBehaviour
    { 
        public float groundSpeed = 5f;
        public float airSpeed = 2f;
        public float speedUp = 500f;
        public LayerMask groundLayer;

        private Collider2D _col;
        private float _speed = 0f;
        private bool _isGroundedToggle = false;

        private void Start()
        {
            _col = GetComponent<Collider2D>();
        }

        private bool IsGrounded()
        {
            return _col.IsTouchingLayers(groundLayer);
        }
        
        private float MovSpeed(float currentSpeed, float buildUp, float limit)
        {
            if (currentSpeed >= limit) return limit;
            
            var increase = buildUp * Time.deltaTime;
            currentSpeed += increase * increase;
            currentSpeed = Math.Min(currentSpeed, limit);
            return currentSpeed;
        }
        
        private void FixedUpdate()
        {
            _speed = IsGrounded() ? MovSpeed(_speed, speedUp, groundSpeed) : MovSpeed(_speed, speedUp, airSpeed);

            transform.Translate(Vector3.right * (_speed * Time.deltaTime));
        }
    }
}
