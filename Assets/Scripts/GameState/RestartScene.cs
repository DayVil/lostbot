using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameState
{
    public class RestartScene : MonoBehaviour
    {
        public void OnRestartButtonClicked()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            Time.timeScale = 1;
        }
    }
}