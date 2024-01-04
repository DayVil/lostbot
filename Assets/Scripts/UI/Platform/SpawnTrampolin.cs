using TMPro;
using UnityEngine;
using Platform;

namespace UI.Platform
{
    public class SpawnTrampoline : MonoBehaviour
    {
        public int amountPlatforms = 3;
        public TextMeshProUGUI text;
        public GameObject platformPrefab;
        public GameObject parentObject;
        public float swayAngle = 10f;
        public float swayTime = 1f;
        
        public float bounceForce = 6f;
        public float bounceTime = 0.5f;
        public Animator animator;

        private readonly Manager _manager = Manager.GetInstance;
        private const string ChildName = "Icon";

        private Transform _iconTransform;
        private Quaternion _startRotation;
        private const string PlatformTag = "UnPlatform";

        private void Start()
        {
            _iconTransform = transform.Find(ChildName);
            _startRotation = _iconTransform.rotation;
            text.text = amountPlatforms.ToString();
        }

        private void Update()
        {
            if (_manager.StartGame) return;
            var endRotation = Quaternion.Euler(0f, 0f, swayAngle);
            _iconTransform.rotation =
                Quaternion.Lerp(_startRotation, endRotation, Mathf.PingPong(Time.time, swayTime) / swayTime);
        }

        public void Spawn()
        {
            if (_manager.StartGame) return;
            if (GameObject.FindWithTag(PlatformTag) != null) return;
            if (amountPlatforms <= 0) return;
            amountPlatforms--;
            text.text = amountPlatforms.ToString();
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
            var trampoline = tmpObj.GetComponent<Trampoline>();
            if (trampoline != null)
            {
                trampoline.bounceForce = bounceForce;
                trampoline.bounceTime = bounceTime;
            }
        }
    }
}
