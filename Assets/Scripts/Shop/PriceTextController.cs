using SOPriceItems;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class PriceTextController : MonoBehaviour
    {
        [SerializeField] private ItemSo _itemSo;

        private TextMeshProUGUI _textPrice;

        private void Start()
        {
            _textPrice = GetComponent<TextMeshProUGUI>();
            _textPrice.text = _itemSo.PriceItem.ToString();
        }
    }
}