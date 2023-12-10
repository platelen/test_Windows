using System;
using UnityEngine;
using UnityEngine.UI;

namespace Road_Levels
{
    public class LevelsController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _levels;

        private int _currentLevelIndex = 0;
        public static event Action<int> OnLevelClicked;
        
        private void Start()
        {
            for (int i = 1; i < _levels.Length; i++)
            {
                _levels[i].transform.GetChild(1).gameObject.SetActive(true);
                _levels[i].transform.GetChild(2).gameObject.SetActive(false);
            }

            Button button = _levels[_currentLevelIndex].GetComponentInChildren<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _levels[_currentLevelIndex].transform.GetChild(3).gameObject.SetActive(true);
            _levels[_currentLevelIndex].transform.GetChild(2).gameObject.SetActive(false);

            _currentLevelIndex = (_currentLevelIndex + 1) % _levels.Length;
            OnLevelClicked?.Invoke(_currentLevelIndex);
            _levels[_currentLevelIndex].transform.GetChild(2).gameObject.SetActive(true);
            _levels[_currentLevelIndex].transform.GetChild(1).gameObject.SetActive(false);

            Button button = _levels[_currentLevelIndex].GetComponentInChildren<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnButtonClick);
        }
    }
}