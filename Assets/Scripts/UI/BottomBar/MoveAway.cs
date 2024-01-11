using GameState;
using UnityEngine;

namespace UI.BottomBar
{
    public class MoveAway : MonoBehaviour
    {
        public int targetVerticalPosition;
        public float speed = 1f;
        public float threshold = 0.1f;

        private Manager _manager;
        private float _targetYPosition;

        private void Start()
        {
            _manager = Manager.GetInstance;
            _targetYPosition = transform.position.y + targetVerticalPosition;
        }

        private void Update()
        {
            if (!_manager.StartGame) return;

            var position = transform.position;
            var targetPosition = new Vector2(position.x, _targetYPosition);
            if (Vector2.Distance(transform.position, targetPosition) < threshold) return;

            var step = speed * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, targetPosition, step);
        }
    }
}