using UnityEngine;

namespace Platform
{
    public class FollowMouse : MonoBehaviour
    {
        public string groundLayer;
        public float alpha = 0.5f;
        private Camera _cam;
        private int _ground;

        private bool _isFollowing = true;
        private bool _isPlacable = true;
        private Color _originalColor;
        private SpriteRenderer _sr;

        private void Start()
        {
            _cam = Camera.main!;
            _sr = GetComponent<SpriteRenderer>();
            _ground = LayerMask.NameToLayer(groundLayer);

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

        private void OnCollisionEnter2D(Collision2D other)
        {
            _isPlacable = false;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _isPlacable = true;
        }

        private void Follow()
        {
            var tmpPos = transform.position;
            var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, tmpPos.z);
        }

        private void DeactivateFollow()
        {
            if (!_isPlacable) return;
            _isFollowing = false;
            gameObject.layer = _ground;
            gameObject.tag = "Platform";
            _sr.color = _originalColor;
        }
    }
}