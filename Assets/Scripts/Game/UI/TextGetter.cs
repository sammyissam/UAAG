using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class TextGetter : MonoBehaviour
    {
        [SerializeField] private GiveText giveText;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;        
        private void Update()
        {
            textMeshProUGUI.text = giveText.GetText();
        }
    }
}