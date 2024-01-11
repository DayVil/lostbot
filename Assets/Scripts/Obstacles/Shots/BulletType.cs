using Utils.MultipleTags;

namespace Obstacles.Shots
{
    public interface IBulletType
    {
        public void SetSpeed(float bulletSpeed);
        public void SetLifeTime(float bulletLifeTime);
        public void SetObjectsToDestroy(EMultiTags[] objectsToDestroy);
    }
}