/**
 * @QumartSeller_ClientServerConnection
 * https://github.com/Nailed34/QumartSeller_ClientServerConnection.git
 *
 * Copyright (c) 2024 https://github.com/Nailed34
 * Released under the MIT license
 */

namespace ClientServerConnection.Actions
{
    public struct InUserAuthorization
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public struct OutUserAuthorization
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string DeclineReason { get; set; }
    }
}
