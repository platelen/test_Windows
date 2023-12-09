using UnityEngine;
using UnityEngine.UI;

namespace Weekly_Bonus
{
    public class DailyRewardManager : MonoBehaviour
    {
        [SerializeField] private Button[] _rewardButtons;

        private int _currentDay = 0;


        private void Start()
        {
            LoadData();

            UpdateRewardButtons();

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