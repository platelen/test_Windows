using SOPriceItems;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class PurchaseButton : MonoBehaviour
    {
        [SerializeField] private BankTicketsPlayer _bankTicketsPlayer;
        [SerializeField] private ItemSo _itemSo;
        [Header("Panels")] 
        [SerializeField] private GameObject _panelTextPrice;
        [SerializeField] private GameObject _panelTicket;
        [SerializeField] private GameObject _panelCheckMark;

        private Button _buttonPurchase;

        private void Start()
        {
            _buttonPurchase = GetComponent<Button>();
            _buttonPurchase.onClick.AddListener(Purchase);
        }

        private void Purchase()
        {
            _bankTicketsPlayer.TicketsPlayer -= _itemSo.PriceItem;
            _panelTicket.SetActive(false);
            _panelTextPrice.SetActive(false);
            _panelCheckMark.SetActive(true);
            Debug.Log($"Tickets Player: {_bankTicketsPlayer.TicketsPlayer}");
        }

        private void OnDestroy()
        {
            _buttonPurchase.onClick.RemoveListener(Purchase);
        }
    }
}