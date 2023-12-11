using Road_Levels;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class OpenPurchaseController : MonoBehaviour
    {
        [SerializeField] private Button _buttonPurchase;
        [SerializeField] private GameObject _panelIcon;
        [SerializeField] private int _completedLevel = -1;
        [SerializeField] private int _setCompletedLevel;

        public GameObject PanelIcon
        {
            get => _panelIcon;
            set => _panelIcon = value;
        }

        private void Start()
        {
            LevelsController.OnLevelClicked += CheckProgress;
            _buttonPurchase.interactable = false;
        }

        private void CheckProgress(int levelIndex)
        {
            if (levelIndex ==
                _setCompletedLevel)
            {
                _completedLevel = levelIndex;
                if (_completedLevel == _setCompletedLevel)
                {
                    Debug.Log(
                        $"Пройден уровен: {_completedLevel}");
                    _panelIcon.SetActive(false);
                    _buttonPurchase.interactable = true;
                }
            }
        }

        
        private void OnDestroy()
        {
            LevelsController.OnLevelClicked -= CheckProgress;
        }
    }
}