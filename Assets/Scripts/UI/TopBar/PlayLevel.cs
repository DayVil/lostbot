using GameState;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TopBar
{
    public class PlayLevel : MonoBehaviour
    {
        public Sprite alternateSprite;
        private readonly Manager _manager = Manager.GetInstance;

        private Image _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<Image>();
        }

        public void Play()
        {
            if (_manager.StartGame) return;
            _manager.StartGame = true;
            _spriteRenderer.sprite = alternateSprite;
        }
    }
}