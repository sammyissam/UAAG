using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utility.UI
{
    public class SubMenu : MonoBehaviour 
    {
        [SerializeField] private GameObject currentMenu;
        [SerializeField]private GameObject menuToGoTo;
        private Button _button;

        private void Start()
        {
            if (currentMenu == null || menuToGoTo == null)
            {
                throw new ArgumentException("Menu values cannot be null");
            }
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            menuToGoTo.gameObject.SetActive(true);
            currentMenu.gameObject.SetActive(false);
        }
    }
}