using UnityEngine;

namespace NPCs.Deaths
{
    public class OnDepth : MonoBehaviour
    {
        public float depth = -10f;
        
        private int _frameCount = 0;
    
        private void Update()
        {
            _frameCount++;
            if (_frameCount % 10 != 0)
            {
                return;
            }
            
            _frameCount = 0;
            if (transform.position.y < depth)
            {
                Destroy(gameObject);
            }
        }
    }
}
