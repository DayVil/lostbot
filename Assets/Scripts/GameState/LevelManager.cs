using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameState
{
    public class LevelManager : MonoBehaviour
    {
        public string sceneName;
        private readonly Manager _manager = Manager.GetInstance;

        public void ChangeScene()
        {
            SceneManager.LoadScene(sceneName);
            _manager.StartGame = false;
            _manager.GameOver = false;
            Time.timeScale = 1;
        }
    }
}