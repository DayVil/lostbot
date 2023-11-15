using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class FollowMouse : MonoBehaviour
    {
        public LayerMask groundLayer;
        public float alpha = 0.5f;
        
        private Camera _cam;
        private int _ground;

        private bool _isFollowing = true;
        private Color _originalColor;
        private SpriteRenderer _sr;
        private List<Collider2D> _allCollisions;

        private void Start()
        {
            _allCollisions = new List<Collider2D>();
            _cam = Camera.main!;
            _sr = GetComponent<SpriteRenderer>();
            _ground = (int)Math.Log(groundLayer, 2);

            _originalColor = _sr.color;
            var grayscale = _originalColor.grayscale;
            var newColor = new Color(grayscale, grayscale, grayscale, alpha);

            _sr.color = newColor;
        }

        private void Update()
        {
            if (!_isFollowing) return;
            if (Input.GetMouseButtonDown(0)) DeactivateFollow();
            Follow();
        }

        // BUG: If platform is inside an object but leaves the collision of another it will be placable
        private void OnCollisionEnter2D(Collision2D other)
        {
            _allCollisions.Add(other.collider);
            
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _allCollisions.Remove(other.collider);
        }

        private void Follow()
        {
            var tmpPos = transform.position;
            var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, tmpPos.z);
        }

        private void DeactivateFollow()
        {
            if (_allCollisions.Count != 0) return;
            _isFollowing = false;
            gameObject.layer = _ground;
            gameObject.tag = "Platform";
            _sr.color = _originalColor;
        }
    }
}