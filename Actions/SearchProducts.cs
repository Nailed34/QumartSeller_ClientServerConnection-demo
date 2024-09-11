/**
 * @QumartSeller_ClientServerConnection
 * https://github.com/Nailed34/QumartSeller_ClientServerConnection-demo.git
 *
 * Copyright (c) 2024 https://github.com/Nailed34
 * Released under the MIT license
 */

namespace ClientServerConnection.Actions
{
    /// <summary>
    /// Class for search products in range
    /// </summary>
    public class InSearchProducts
    {
        public string SearchRequest { get; set; } = "";
        public int FirstIndex { get; set; } = 0;
        public int LastIndex { get; set; } = 0;
    }

    /// <summary>
    /// Server response, contains serialized products and found products count
    /// </summary>
    public class OutSearchProducts
    {
        public List<string> FoundProducts { get; set; } = new List<string>();
        public int FoundProductsCount { get; set; } = 0;
    }
}
