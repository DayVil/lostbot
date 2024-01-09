using GameState;
using UnityEngine;

namespace UI.Bottom_Bar
{
    public class MoveAway : MonoBehaviour
    {
        public int targetVerticalPosition;
        public float speed = 1f;
        public float threshold = 0.1f;

        private Manager _manager;

        private void Start()
        {
            _manager = Manager.GetInstance;
        }

        private void Update()
        {
            if (!_manager.StartGame) return;

            var targetPosition = new Vector2(transform.position.x, targetVerticalPosition);
            if (Vector2.Distance(transform.position, targetPosition) < threshold) return;

            var step = speed * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, targetPosition, step);
        }
    }
}