using GameState;
using UnityEngine;
using Utils.MultipleTags;

namespace Obstacles.Shots
{
    public class Canon : MonoBehaviour
    {
        public GameObject bullet;

        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private float bulletLifeTime = 5f;
        [SerializeField] private EMultiTags[] lethalTo;
        [SerializeField] private float fireRate = 1f;

        private readonly Manager _manager = Manager.GetInstance;

        private void Start()
        {
            var bulletsType = bullet.GetComponent<IBulletType>();
            if (bulletsType == null) throw new MissingComponentException("Bullet type not found");
            bulletsType.SetSpeed(bulletSpeed);
            bulletsType.SetLifeTime(bulletLifeTime);
            bulletsType.SetObjectsToDestroy(lethalTo);

            InvokeRepeating(nameof(Shoot), 0f, fireRate);
            Shoot();
        }

        private void Shoot()
        {
            if (!_manager.StartGame) return;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}