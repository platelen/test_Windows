using UnityEngine;

namespace SOPriceItems
{
    [CreateAssetMenu(fileName = "Item", menuName = "Create Item")]
    public class ItemSo : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private float _priceItem;

        public string ItemName => _itemName;

        public float PriceItem => _priceItem;
    }
}