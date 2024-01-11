using GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.TopBar
{
    public class RestartLevel : MonoBehaviour
    {
        private readonly Manager _manager = Manager.GetInstance;

        public void Restart()
        {
            if (!_manager.StartGame) return;
            _manager.GameOver = false;
            _manager.StartGame = false;
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            Time.timeScale = 1;
        }
    }
}