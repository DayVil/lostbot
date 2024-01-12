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
        [SerializeField] private float startFireRate = 0.8f;

        private readonly Manager _manager = Manager.GetInstance;
        private float _currentTime;

        private void Start()
        {
            _currentTime = fireRate * startFireRate;
        }

        private void Update()
        {
            if (!_manager.StartGame) return;
            _currentTime += Time.deltaTime;
            if (!(_currentTime >= fireRate)) return;
            Shoot();
            _currentTime = 0;
        }

        private void Shoot()
        {
            if (!_manager.StartGame) return;
            var tmpObj = Instantiate(bullet, transform.position, Quaternion.identity);
            var bulletsType = tmpObj.GetComponent<IBulletType>();
            if (bulletsType == null) throw new MissingComponentException("Bullet type not found");
            bulletsType.SetSpeed(bulletSpeed);
            bulletsType.SetLifeTime(bulletLifeTime);
            bulletsType.SetObjectsToDestroy(lethalTo);

            tmpObj.transform.parent = transform;
        }
    }
}