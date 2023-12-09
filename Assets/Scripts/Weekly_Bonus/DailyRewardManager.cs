using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Weekly_Bonus
{
    public class DailyRewardManager : MonoBehaviour
    {
        [SerializeField] private GameObject _panelWeeklyBonus;
        [SerializeField] private GameObject _panelDailyBonus;
        [SerializeField] private Button[] _rewardButtons;
        [SerializeField] private int _maxDay = 7;
        [SerializeField] private BarDay _sliderBarDay;
        [SerializeField] private TextMeshProUGUI _textCurrentDay;

        private int _currentDay = 0;

        private void Awake()
        {
            _sliderBarDay.SetMaxDay(_maxDay);
        }

        private void Start()
        {
            LoadData();

            if (_currentDay > 7)
            {
                ResetData();
            }

            UpdateRewardButtons();
            _sliderBarDay.SetBarDay(_currentDay);
            _textCurrentDay.text = _currentDay.ToString();

            if (_currentDay > 6)
            {
                _panelWeeklyBonus.SetActive(false);
                _panelDailyBonus.SetActive(true);
            }


            Debug.Log($"Current_Day: {_currentDay}");
        }

        private void UpdateRewardButtons()
        {
            for (int i = 0; i < _rewardButtons.Length; i++)
            {
                bool isButtonActive = i <= _currentDay;

                _rewardButtons[i].interactable = isButtonActive;
            }
        }

        private void ClaimReward()
        {
            _currentDay++;

            SaveData();
            UpdateRewardButtons();
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt("CurrentDay", _currentDay);
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            _currentDay = PlayerPrefs.GetInt("CurrentDay", 0);
        }

        public void ResetData()
        {
            PlayerPrefs.DeleteKey("CurrentDay");
            LoadData();
            UpdateRewardButtons();
        }

        private void OnApplicationQuit()
        {
            ClaimReward();
        }
    }
}