using TMPro;
using UnityEngine;

namespace UI
{
    public class SpawnPlatform : MonoBehaviour
    {
        public int amountPlatforms = 3;
        public TextMeshProUGUI text;
        public GameObject platformPrefab;
        public GameObject parentObject;

        private readonly Manager _manager = Manager.GetInstance;
        private const string PlatformTag = "UnPlatform";

        private void Start()
        {
            text.text = amountPlatforms.ToString();
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
            Utils.ChangeSize(1.1f, tmpObj);
        }
    }
}