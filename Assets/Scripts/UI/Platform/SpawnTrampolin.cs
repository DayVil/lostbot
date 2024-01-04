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
        
        public float bounceForce = 6f;
        public float bounceTime = 0.5f;

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
            var trampoline = tmpObj.GetComponent<Trampoline>();
            if (trampoline != null)
            {
                trampoline.bounceForce = bounceForce;
                trampoline.bounceTime = bounceTime;
            }
        }
    }
}
