using UnityEngine;
using UnityEngine.UI;

namespace Weekly_Bonus
{
    public class BackToHomeInDailyBonus : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panelsDailyBonus;
        [SerializeField] private GameObject _panelMainMenu;

        private Button _buttonBackToHome;

        private void Awake()
        {
            _buttonBackToHome = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _buttonBackToHome.onClick.AddListener(DisabledPanelsDailyBonus);
        }

        private void OnDisable()
        {
            _buttonBackToHome.onClick.RemoveListener(DisabledPanelsDailyBonus);
        }

        private void DisabledPanelsDailyBonus()
        {
            foreach (GameObject panels in _panelsDailyBonus)
            {
                panels.SetActive(false);
            }

            _panelMainMenu.SetActive(true);
        }
    }
}