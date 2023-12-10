using Road_Levels;
using SOLevelCompleted;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class OpenPurchaseController : MonoBehaviour
    {
        [SerializeField] private SoLevelNumberCompleted _soLevelNumberCompleted;
        [SerializeField] private Button _buttonPurchase;
        [SerializeField] private GameObject _panelIcon;
        public int completedLevel = -1;

        private void Start()
        {
            LevelsController.OnLevelClicked += CheckProgress;
            _buttonPurchase.interactable = false;
        }

        private void CheckProgress(int levelIndex)
        {
            if (levelIndex == 3) // предположим, что нам нужно активировать GameObject при пройденном третьем уровне
            {
                completedLevel = levelIndex; // помечаем, что третий уровень пройден
                if (completedLevel == 3)
                {
                    Debug.Log(
                        $"Пройден уровен: {completedLevel}"); // активируем GameObject, если третий уровень пройден
                }
            }
            // Здесь вы можете добавить другие проверки для других уровней
        }

        private void OnDestroy()
        {
            LevelsController.OnLevelClicked -= CheckProgress;
        }
    }
}