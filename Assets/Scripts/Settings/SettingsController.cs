using Music;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private BackgroundMusic _backgroundMusic;
        [SerializeField] private GameObject _panelMenu;
        [SerializeField] private Button _buttonHome;
        [SerializeField] private Button _buttonMusic;
        [SerializeField] private Button _buttonSpeaker;
        [SerializeField] private float _increasingVolume = 0.2f;

        private void OnEnable()
        {
            _buttonHome.onClick.AddListener(BackToMenu);
            _buttonMusic.onClick.AddListener(ToggleMuteButton);
            _buttonSpeaker.onClick.AddListener(() => IncreaseVolumeButton(_increasingVolume));
        }

        private void OnDisable()
        {
            _buttonHome.onClick.RemoveListener(BackToMenu);
            _buttonMusic.onClick.RemoveListener(ToggleMuteButton);
            _buttonSpeaker.onClick.RemoveListener(() => IncreaseVolumeButton(_increasingVolume));
        }

        private void BackToMenu()
        {
            _panelMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        public void ToggleMuteButton()
        {
            _backgroundMusic.ToggleMute();
        }

        public void IncreaseVolumeButton(float amount)
        {
            _backgroundMusic.IncreaseVolume(amount);
        }
    }
}