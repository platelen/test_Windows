using UnityEngine;
using UnityEngine.UI;

namespace Weekly_Bonus
{
    public class DisableButtonDay : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panelsWeekly;
        [SerializeField] private GameObject _panelMainMenu;
        private Button _buttonDay;

        private void Awake()
        {
            _buttonDay = GetComponent<Button>();
            _buttonDay.onClick.AddListener(DisabledPanelsWeekly);
        }

        private void DisabledPanelsWeekly()
        {
            Debug.Log($"Test: {_buttonDay.name}");
            foreach (GameObject panels in _panelsWeekly)
            {
                panels.SetActive(false);
            }

            _panelMainMenu.SetActive(true);
        }

        private void OnDestroy()
        {
            _buttonDay.onClick.RemoveListener(DisabledPanelsWeekly);
        }
    }
}