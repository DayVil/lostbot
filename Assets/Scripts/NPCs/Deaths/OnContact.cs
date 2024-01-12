using System;
using GameState;
using UnityEngine;

namespace NPCs.Deaths
{
    public class OnContact : MonoBehaviour
    {
        public LayerMask contactLayer;
        public float spawnProtection = 1f;
        private readonly Manager _manager = Manager.GetInstance;

        private Collider2D _col;
        private Vector3 _curPos;
        private float _timer;

        private void Start()
        {
            _col = GetComponent<Collider2D>();
            _timer = spawnProtection;
        }

        private void LateUpdate()
        {
            if (!_manager.StartGame) return;
            if (_manager.GameOver) return; 
            if (_col.IsTouchingLayers(contactLayer))
            {
                Destroy(gameObject);
            }

            if (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                return;
            }

            var tmpCurPos = transform.position;
            if (Math.Abs(_curPos.y - tmpCurPos.y) < 0.01f)
            {
                if (Math.Abs(tmpCurPos.x - _curPos.x) < 0.01f)
                {
                    Destroy(gameObject);
                }
            }

            _curPos = tmpCurPos;
            _timer = spawnProtection;
        }
    }
}