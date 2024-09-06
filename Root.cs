/**
 * @QumartSeller_ClientServerConnection
 * https://github.com/Nailed34/QumartSeller_ClientServerConnection-demo.git
 *
 * Copyright (c) 2024 https://github.com/Nailed34
 * Released under the MIT license
 */

using System.Text.Json;

namespace ClientServerConnection
{
    /// <summary>
    /// List of marketplaces
    /// </summary>
    public enum EMarketplaces
    {
        None,
        Ozon,
        Wildberries,
        YandexMarket
    }

    /// <summary>
    /// Product onion and attached cards client presentation
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Serialize product info to string for send it to client
        /// </summary>
        public static string SerializeProductInfo(ProductInfo productInfo)
        {
            return JsonSerializer.Serialize(productInfo);
        }

        /// <summary>
        /// Serialize product info to string for send it to client
        /// </summary>
        public static List<string> SerializeProductInfo(List<ProductInfo> productInfo)
        {
            List<string> result = new List<string>();
            foreach (var item in productInfo)
                result.Add(JsonSerializer.Serialize(item));
            return result;
        }

        /// <summary>
        /// Deserialize product info from string by server response
        /// </summary>
        public static ProductInfo DeserializeProductInfo(string productInfo)
        {
            return JsonSerializer.Deserialize<ProductInfo>(productInfo) ?? new ProductInfo();
        }

        /// <summary>
        /// Deserialize product info from string by server response
        /// </summary>
        public static List<ProductInfo> DeserializeProductInfo(List<string> productInfo)
        {
            List<ProductInfo> result = new List<ProductInfo>();
            foreach (var item in productInfo)
                result.Add(JsonSerializer.Deserialize<ProductInfo>(item) ?? new ProductInfo());
            return result;
        }

        /// <summary>
        /// Onion id from DB
        /// </summary>
        public string id { get; set; } = "";

        /// <summary>
        /// Name of onion determines by priority marketplace
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// Photo of product determines by priority marketplace
        /// </summary>
        public string photo { get; set; } = "";
        /// <summary>
        /// General stocks for child cards
        /// </summary>
        public int stocks { get; set; } = 0;
        /// <summary>
        /// List of child cards articuls
        /// </summary>
        public List<string> articuls { get; set; } = new();
        /// <summary>
        /// List of child cards barcodes
        /// </summary>
        public List<string> barcodes { get; set; } = new();
        /// <summary>
        /// List of child cards marketplaces
        /// </summary>
        public List<EMarketplaces> marketplaces { get; set; } = new();
        /// <summary>
        /// List of child cards db indexes with marketplaces
        /// </summary>
        public List<ProductInfoCard> cards { get; set; } = new();
    }

    /// <summary>
    /// Attached cards client presentation
    /// </summary>
    public class ProductInfoCard
    {
        /// <summary>
        /// Seller articul
        /// </summary>
        public string articul { get; set; } = "";
        /// <summary>
        /// Product card name determines by seller in marketplace
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// Current product card stocks
        /// </summary>
        public int stocks { get; set; } = 0;
        /// <summary>
        /// Product card creation data from marketplace
        /// </summary>
        public DateTime creation_date { get; set; } = new();
        /// <summary>
        /// Flag for change stocks in other cards in onion. If false update only this card
        /// </summary>
        public bool is_synch { get; set; } = true;
        /// <summary>
        /// Count of products for update other cards in onion.
        /// Example: 2 cards of 1 product, different by count.
        /// This count should be indicated in the multiplicity
        /// </summary>
        public int multiplicity { get; set; } = 1;
        /// <summary>
        /// Marketplace where product card from
        /// </summary>
        public EMarketplaces marketplace { get; set; } = EMarketplaces.None;
        /// <summary>
        /// Barcodes of product card
        /// </summary>
        public List<string> barcodes { get; set; } = new();
    }
}
