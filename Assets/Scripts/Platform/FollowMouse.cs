using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Platform
{
    public class FollowMouse : MonoBehaviour
    {
        public LayerMask groundLayer;
        
        private bool _isFollowing = true;
        private Camera _cam;
        private Collider2D _col;
        
        private void Start()
        {
            _cam = Camera.main!;
            _col = GetComponent<Collider2D>();
            _col.enabled = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) DeactivateFollow();
            if (_isFollowing) Follow();
        }

        private void Follow()
        {
            var tmpPos = transform.position;
            var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, tmpPos.z);
        }

        private void DeactivateFollow()
        {
            _isFollowing = false;
            _col.enabled = true;
            // gameObject.layer = groundLayer;
        }
    }
}
