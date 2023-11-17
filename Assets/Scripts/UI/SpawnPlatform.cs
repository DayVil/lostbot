using UnityEngine;

namespace UI
{
    public class SpawnPlatform : MonoBehaviour
    {
        public string platformTag = "UnPlatform";
        public GameObject platformPrefab;
        public GameObject parentObject;

        private readonly Manager _manager = Manager.GetInstance;
        
        public void Spawn()
        {
            if (_manager.StartGame) return;
            if (GameObject.FindWithTag(platformTag) != null) return;
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
        }
    }
}