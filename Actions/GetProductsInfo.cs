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
    /// Struct for get onions in range
    /// </summary>
    public class InGetProductsInfo
    {
        public int FirstIndex { get; set; } = 0;
        public int LastIndex { get; set; } = 0;
    }

    /// <summary>
    /// Server response, contains serialized products and all products count
    /// </summary>
    public class OutGetProductsInfo
    {
        public List<string> ProductsInfo { get; set; } = new List<string>();
        public int ProductsCount { get; set; } = 0;
    }
}
