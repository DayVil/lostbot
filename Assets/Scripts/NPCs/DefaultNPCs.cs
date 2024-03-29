using GameState;
using UnityEngine;

namespace NPCs
{
    public class MoveRight : MonoBehaviour
    {
        public Animator animator;

        public float groundSpeed = 5f;
        public float airSpeed = 2f;
        public float speedUp = 500f;
        public LayerMask groundLayer;
        private readonly Manager _manager = Manager.GetInstance;

        private Collider2D _col;
        private float _currentSpeed;

        private void Start()
        {
            _col = GetComponent<Collider2D>();
        }

        private void FixedUpdate()
        {
            if (!_manager.StartGame) return;
            if(_manager.GameOver) {
                animator.SetBool("isRunning", false);
                return;
            }
            animator.SetBool("isRunning", true);
            _currentSpeed = IsGrounded()
                ? MoveSpeed(_currentSpeed, speedUp, groundSpeed)
                : MoveSpeed(_currentSpeed, speedUp, airSpeed);

            transform.Translate(Vector3.right * (_currentSpeed * Time.deltaTime));
        }

        private bool IsGrounded()
        {
            return _col.IsTouchingLayers(groundLayer);
        }

        private float MoveSpeed(float currentSpeed, float buildUp, float limit)
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
    }
}