using UnityEngine;

namespace NPCs
{
    public class MoveRight : MonoBehaviour
    { 
        public float groundSpeed = 5f;
        public float airSpeed = 2f;
        public float speedUp = 500f;
        public LayerMask groundLayer;

        private Collider2D _col;
        private float _currentSpeed;

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
            var increase = buildUp * Time.deltaTime;
            if (currentSpeed >= limit)
            {
                currentSpeed -= increase * increase * 0.1f;
            }
            else
            {
                currentSpeed += increase * increase;
            }
            return currentSpeed;
        }
    
        private void FixedUpdate()
        {
            _currentSpeed = IsGrounded() ? MovSpeed(_currentSpeed, speedUp, groundSpeed) : MovSpeed(_currentSpeed, speedUp, airSpeed);

            transform.Translate(Vector3.right * (_currentSpeed * Time.deltaTime));
        }
    }
}
