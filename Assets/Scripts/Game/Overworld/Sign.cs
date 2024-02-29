using TMPro;
using UnityEngine;

namespace Game.Overworld
{
    public class Sign : MonoBehaviour
    {
        public TMP_Text dialogue;
        public GameObject dialogueCanvas;

        [TextArea]
        public string wordsToSay;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            dialogueCanvas.SetActive(true);
            dialogue.text = wordsToSay;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            dialogueCanvas.SetActive(false);
            dialogue.text = "";
        }

    }
}
