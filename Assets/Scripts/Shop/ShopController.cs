using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Shop
{
    public class ShopController : MonoBehaviour, IStoreListener
    {
        private static IStoreController storeController;
        private static IExtensionProvider extensionProvider;

        public string productID;

        private void Awake()
        {
            ResourceRequest operation = Resources.LoadAsync<TextAsset>("IAPProductCatalog");
            operation.completed += HandleIAPCatalogLoaded;
        }

        private void HandleIAPCatalogLoaded(AsyncOperation operation)
        {
            ResourceRequest request = operation as ResourceRequest;
            Debug.Log($"Loaded Asset: {request.asset}");
            ProductCatalog catalog = JsonUtility.FromJson<ProductCatalog>((request.asset as TextAsset).text);
            Debug.Log($"Loaded catalog with {catalog.allProducts.Count} items");

            ConfigurationBuilder builder = ConfigurationBuilder.Instance(
                StandardPurchasingModule.Instance(AppStore.GooglePlay));

            foreach (ProductCatalogItem item in catalog.allProducts)
            {
                builder.AddProduct(item.id, item.type);
            }

            UnityPurchasing.Initialize(this, builder);
        }

        void Start()
        {
            //InitializePurchasing();
        }

        private void InitializePurchasing()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(productID, ProductType.Consumable);

            UnityPurchasing.Initialize(this, builder);
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            storeController = controller;
            extensionProvider = extensions;
            Debug.Log("IAP initialization...");
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogError("IAP initialization failed: " + error);
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.LogError("Purchase of product " + product.definition.id + " failed. Reason: " + failureReason);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            // Здесь обработайте успешную покупку, например, активируйте функционал товара
            Debug.Log("Purchase successful: " + args.purchasedProduct.definition.id);

            return PurchaseProcessingResult.Complete;
        }

        public void PurchaseProduct()
        {
            // Проверка, поддерживается ли продукт
            if (storeController != null && storeController.products != null)
            {
                Product product = storeController.products.WithID(productID);

                // Проверка, найден ли продукт
                if (product != null && product.availableToPurchase)
                {
                    // Запуск процесса покупки
                    storeController.InitiatePurchase(product);
                }
                else
                {
                    Debug.LogError("Unable to purchase. Product not found or not available.");
                }
            }
            else
            {
                Debug.LogError("Unable to purchase. IAP not initialized.");
            }
        }
    }
}