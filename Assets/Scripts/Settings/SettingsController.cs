using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private GameObject _panelMenu;
        [SerializeField] private Button _buttonHome;

        private void OnEnable()
        {
            _buttonHome.onClick.AddListener(BackToMenu);
        }

        private void OnDisable()
        {
            _buttonHome.onClick.RemoveListener(BackToMenu);
        }

        private void BackToMenu()
        {
            _panelMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}