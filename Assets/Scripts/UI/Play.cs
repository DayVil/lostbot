using TMPro;
using UnityEngine;

namespace UI
{
    public class Play : MonoBehaviour
    {
        public string changeName;
        public TextMeshProUGUI playText;

        public void ChangeText()
        {
            playText.text = changeName;
        }
    }
}