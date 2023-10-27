using System;
using UnityEngine;

namespace NPCs.Deaths
{
    public class OnContact : MonoBehaviour
    {
        public LayerMask contactLayer;
        public float spawnProtection = 1f;
        
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
            if (Math.Abs(tmpCurPos.x - _curPos.x) < 0.01f)
            {
                Destroy(gameObject);
            }
            _curPos = tmpCurPos;
            _timer = spawnProtection; 
        }
    }
}