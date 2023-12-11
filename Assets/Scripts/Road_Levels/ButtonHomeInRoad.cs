using UnityEngine;
using UnityEngine.UI;

namespace Road_Levels
{
    public class ButtonHomeInRoad : MonoBehaviour
    {
        [SerializeField] private GameObject _panelRoadLevel;
        [SerializeField] private GameObject _panelMenuView;
        [SerializeField] private GameObject[] _panelsShop;


        private Button _buttonBackToMenu;

        private void Start()
        {
            _buttonBackToMenu = GetComponent<Button>();
            _buttonBackToMenu.onClick.AddListener(BackToMenu);
        }

        private void BackToMenu()
        {
            _panelRoadLevel.SetActive(false);
            foreach (GameObject panel in _panelsShop)
            {
                panel.SetActive(false);
            }
            _panelMenuView.SetActive(true);
        }

        private void OnDestroy()
        {
            _buttonBackToMenu.onClick.RemoveListener(BackToMenu);
        }
    }
}