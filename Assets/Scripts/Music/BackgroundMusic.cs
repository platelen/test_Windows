using UnityEngine;

namespace Music
{
    public class BackgroundMusic : MonoBehaviour
    {
        public AudioSource _audioSource;
        private bool _isMuted;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;

            UpdateAudioState();
        }

        private void UpdateAudioState()
        {
            _audioSource.mute = _isMuted;
            PlayerPrefs.SetInt("IsMuted", _isMuted ? 1 : 0);
        }

        public void ToggleMute()
        {
            _isMuted = !_isMuted;
            if (_isMuted)
            {
                _audioSource.volume = 0f;
            }
            else
            {
                _audioSource.volume = 1f;
            }
            UpdateAudioState();
        }

        public void IncreaseVolume(float amount)
        {
            _isMuted = false;
            _audioSource.volume += amount;
            UpdateAudioState();
        }
    }
}
