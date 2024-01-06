using Platform;
using TMPro;
using UnityEngine;

namespace UI.Platform
{
    public class SpawnTrampoline : MonoBehaviour
    {
        private const string PlatformTag = "UnPlatform";
        public int amountPlatforms = 3;
        public TextMeshProUGUI text;
        public GameObject platformPrefab;
        public GameObject parentObject;

        public float bounceForce = 6f;
        public float bounceTime = 0.5f;

        private readonly Manager _manager = Manager.GetInstance;
        private readonly string tag = "TrampolinePlat";
        private int _amountPlatforms;

        private void Start()
        {
            _amountPlatforms = amountPlatforms;
            text.text = _amountPlatforms.ToString();
        }

        private void Update()
        {
            _amountPlatforms = amountPlatforms - Utils.CountTags(tag);
            text.text = _amountPlatforms.ToString();
        }

        public void Spawn()
        {
            if (_manager.StartGame) return;
            if (GameObject.FindWithTag(PlatformTag) != null) return;
            if (_amountPlatforms <= 0) return;
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
            var trampoline = tmpObj.GetComponent<Trampoline>();
            if (trampoline != null)
            {
                trampoline.bounceForce = bounceForce;
                trampoline.bounceTime = bounceTime;
            }

            Utils.ChangeSize(0.9f, tmpObj);
        }
    }
}