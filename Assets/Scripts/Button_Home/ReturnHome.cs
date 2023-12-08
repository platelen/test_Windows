using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Button_Home
{
    public class ReturnHome : MonoBehaviour
    {
        private Button _buttonHome;

        private void Awake()
        {
            _buttonHome = GetComponent<Button>();
            _buttonHome.onClick.AddListener(BackToMenu);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        private void OnDestroy()
        {
            _buttonHome.onClick.RemoveListener(BackToMenu);
        }
    }
}