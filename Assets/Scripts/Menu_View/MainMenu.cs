using Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu_View
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Bank")] 
        [SerializeField] private BankTicketsPlayer _bankTicketsPlayer;
        [SerializeField] private TextMeshProUGUI _textBankTickets;
        [Header("Buttons")]
        [SerializeField] private Button _buttonStartLevels;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonShop;
        [SerializeField] private Button _buttonWeekly;
        [Header("Panels")] 
        [SerializeField] private GameObject _panelLevels;
        [SerializeField] private GameObject[] _panelsSettings;
        [SerializeField] private GameObject _panelWeekly;
        [SerializeField] private GameObject[] _panelsShop;
        [SerializeField] private GameObject _panelShop;


        private void Start()
        {
            _textBankTickets.text = _bankTicketsPlayer.TicketsPlayer.ToString();
        }

        private void Update()
        {
            _textBankTickets.text = _bankTicketsPlayer.TicketsPlayer.ToString();
        }

        private void OnEnable()
        {
            _buttonSettings.onClick.AddListener(OpenSetting);
            _buttonShop.onClick.AddListener(OpenShop);
            _buttonWeekly.onClick.AddListener(OpenWeekly);
            _buttonStartLevels.onClick.AddListener(StartLevels);
        }

        private void OnDisable()
        {
            _buttonSettings.onClick.RemoveListener(OpenSetting);
            _buttonShop.onClick.RemoveListener(OpenShop);
            _buttonWeekly.onClick.RemoveListener(OpenWeekly);
            _buttonStartLevels.onClick.RemoveListener(StartLevels);
        }

        private void StartLevels()
        {
            _panelLevels.SetActive(true);
            foreach (GameObject panels in _panelsShop)
            {
                panels.SetActive(true);
            }

            gameObject.SetActive(false);
        }

        private void OpenSetting()
        {
            foreach (GameObject panels in _panelsSettings)
            {
                panels.SetActive(true);
            }

            gameObject.SetActive(false);
        }

        private void OpenWeekly()
        {
            _panelWeekly.SetActive(true);
            gameObject.SetActive(false);
        }

        private void OpenShop()
        {
            _panelShop.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}