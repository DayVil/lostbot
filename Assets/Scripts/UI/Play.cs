using GameState;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Play : MonoBehaviour
    {
        public string changeName;
        public TextMeshProUGUI playText;

        private readonly Manager _manager = Manager.GetInstance;

        private void Start()
        {
            _manager.StartGame = false;
        }

        public void ChangeText()
        {
            _manager.StartGame = true;
            playText.text = changeName;
        }
    }
}