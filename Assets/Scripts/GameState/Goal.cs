using UnityEngine;

namespace GameState
{
    public class Goal : MonoBehaviour
    {
        public GameObject menuPanel;
        private readonly Manager _manager = Manager.GetInstance;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "NPCPlayer")
            {
                Time.timeScale = 0f;
                Debug.Log("You Win!");
                _manager.GameOver = true;
                menuPanel.SetActive(true);
            }
        }
    }
}