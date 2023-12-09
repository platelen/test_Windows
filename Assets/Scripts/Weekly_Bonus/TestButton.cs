using UnityEngine;
using UnityEngine.UI;

namespace Weekly_Bonus
{
    public class TestButton : MonoBehaviour
    {
        private Button _buttonDay;

        private void Awake()
        {
            _buttonDay = GetComponent<Button>();
            _buttonDay.onClick.AddListener(Test);
        }

        private void Test()
        {
            Debug.Log($"Test: {_buttonDay.name}");

            GameObject rootPanel = transform.root.gameObject;
            rootPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            _buttonDay.onClick.RemoveListener(Test);
        }
    }
}