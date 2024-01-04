using TMPro;
using UnityEngine;

namespace UI.Platform
{
    public class SwayAnimation : MonoBehaviour
    {
        public float swayAngle = 10f;
        public float swayTime = 1f;
        
        private readonly Manager _manager = Manager.GetInstance;
        private const string ChildName = "Icon";
        private Transform _iconTransform;
        private Quaternion _startRotation;
        
        private void Start()
        {
            _iconTransform = transform.Find(ChildName);
            _startRotation = _iconTransform.rotation;
        }
        
        private void Update()
        {
            if (_manager.StartGame) return;
            var endRotation = Quaternion.Euler(0f, 0f, swayAngle);
            _iconTransform.rotation =
                Quaternion.Lerp(_startRotation, endRotation, Mathf.PingPong(Time.time, swayTime) / swayTime);
        }
    }
}
