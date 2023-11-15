using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Play : MonoBehaviour
    {
        public string changeName;
        public TextMeshProUGUI playText;

        private float _oldTimeScale;

        private void Start()
        {
            _oldTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }

        public void ChangeText()
        {
            playText.text = changeName;
            Time.timeScale = _oldTimeScale;
        }
    }
}