using BepInEx;
using BepInEx.Configuration;

namespace ValheimWebSocket
{

    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class ValheimWebSocketPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "org.bepinex.plugins.valheim_websocket";
        public const string pluginName = "Valheim WebSocket";
        public const string pluginVersion = "0.1.0";
        
        private ConfigEntry<int> serverPort;

        void Awake()
        {
            UnityEngine.Debug.Log($"[VWS] {pluginName} v{pluginVersion}");

            serverPort = Config.Bind("Server", "Port", 60157, "WebSocket server port");
            
            try
            {
                Classes.ValheimWebSocketServer.Start(serverPort.Value);
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
            }
        }
    }
}