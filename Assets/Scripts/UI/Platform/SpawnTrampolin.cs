using Platform;
using TMPro;
using UnityEngine;

namespace UI.Platform
{
    public class SpawnTrampoline : MonoBehaviour
    {
        private const string PlatformTag = "UnPlatform";
        private const string Tag = "TrampolinePlat";
        public int amountPlatforms = 3;
        public TextMeshProUGUI text;
        public GameObject platformPrefab;
        public GameObject parentObject;

        public float bounceForce = 6f;
        public float bounceTime = 0.5f;

        private readonly Manager _manager = Manager.GetInstance;
        private int _amountPlatforms;

        private void Start()
        {
            _amountPlatforms = amountPlatforms;
            text.text = _amountPlatforms.ToString();
        }

        private void Update()
        {
            if (_manager.StartGame) return;
            _amountPlatforms = amountPlatforms - Utils.CountTags(Tag);
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