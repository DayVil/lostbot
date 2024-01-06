using TMPro;
using UnityEngine;

namespace UI.Platform
{
    public class SpawnPlatform : MonoBehaviour
    {
        private const string PlatformTag = "UnPlatform";
        private const string Tag = "BasePlat";
        public int amountPlatforms = 3;
        public TextMeshProUGUI text;
        public GameObject platformPrefab;
        public GameObject parentObject;

        private readonly Manager _manager = Manager.GetInstance;
        private int _amountPlatforms;

        private void Start()
        {
            _amountPlatforms = amountPlatforms;
            text.text = amountPlatforms.ToString();
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
            if (amountPlatforms <= 0) return;
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
            Utils.ChangeSize(1.1f, tmpObj);
        }
    }
}