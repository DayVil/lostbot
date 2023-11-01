using UnityEngine;

namespace UI
{
    public class SpawnPlatform : MonoBehaviour
    {
        public string platformTag = "UnPlatform";
        public GameObject platformPrefab;
        public GameObject parentObject;

        public void Spawn()
        {
            if (GameObject.FindWithTag(platformTag) != null) return;
            var tmpObj = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            tmpObj.transform.parent = parentObject.transform;
        }
    }
}