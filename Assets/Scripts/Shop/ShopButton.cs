using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopButton : MonoBehaviour
    {
        private ShopController iapManager;

        private void Start()
        {
            iapManager = GetComponent<ShopController>();

            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            iapManager.PurchaseProduct();
        }
    }
}