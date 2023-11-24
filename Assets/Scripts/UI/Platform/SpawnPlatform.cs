using UnityEngine;

namespace UI
{
    public class SpawnPlatform : MonoBehaviour
    {
        public string platformTag = "UnPlatform";
        public string childName = "Icon";
        public GameObject platformPrefab;
        public GameObject parentObject;
        public float swayAngle = 10f;
        public float swayTime = 1f;

        private readonly Manager _manager = Manager.GetInstance;

        // private List<Transform> _childrenList = new();
        private Transform _iconTransform;
        private Quaternion _startRotation;

        private void Start()
        {
            _iconTransform = transform.Find(childName);
            _startRotation = _iconTransform.rotation;
            // for (int i = 0; i < parentObject.transform.childCount; i++)
            // {
            //     _childrenList.Add(parentObject.transform.GetChild(i));
            // }
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
            if (GameObject.FindWithTag(platformTag) != null) return;
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
        }
    }
}