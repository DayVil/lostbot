using GameState;
using UnityEngine;
using Utils.MultipleTags;

namespace Obstacles.Shots
{
    public class CanonShot : MonoBehaviour, IBulletType
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private EMultiTags[] tagsToDestroy;

        private readonly Manager _manager = Manager.GetInstance;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void FixedUpdate()
        {
            if (!_manager.StartGame) return;
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var multiTags = other.gameObject.GetComponent<MultiTags>();
            if (multiTags != null)
                if (multiTags.HasAnyTag(tagsToDestroy))
                    Destroy(other.gameObject);
            Destroy(gameObject);
        }

        public void SetSpeed(float bulletSpeed)
        {
            speed = bulletSpeed;
        }

        public void SetLifeTime(float bulletLifeTime)
        {
            lifeTime = bulletLifeTime;
        }

        public void SetObjectsToDestroy(EMultiTags[] objectsToDestroy)
        {
            tagsToDestroy = objectsToDestroy;
        }
    }
}