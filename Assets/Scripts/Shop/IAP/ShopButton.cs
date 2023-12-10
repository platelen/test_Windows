using UnityEngine;
using UnityEngine.UI;

namespace Shop.IAP
{
    public class ShopButton : MonoBehaviour
    {
        private ShopIAPController iapManager;

        private void Start()
        {
            iapManager = GetComponent<ShopIAPController>();

            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            iapManager.PurchaseProduct();
        }
    }
}