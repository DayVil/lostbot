using GameState;
using TMPro;
using UnityEngine;

namespace UI.Platform
{
    public class GeneralSpawner : MonoBehaviour
    {
        private const string PlatformTag = "UnPlatform";
        public string placeTag = "BasePlat";
        public int amountPlatforms = 3;
        public TextMeshProUGUI text;
        public GameObject platformPrefab;
        public GameObject parentObject;
        public float scaleFactor = 1f;

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
            _amountPlatforms = amountPlatforms - Utils.Utils.CountTags(placeTag);
            text.text = _amountPlatforms.ToString();
        }

        public void Spawn()
        {
            if (_manager.StartGame) return;
            if (GameObject.FindWithTag(PlatformTag) != null) return;
            if (_amountPlatforms <= 0) return;
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
            Utils.Utils.ChangeSize(scaleFactor, tmpObj);
        }
    }
}