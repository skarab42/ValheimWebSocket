using BepInEx;

namespace ValheimWebSocket
{

    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class ValheimWebSocketPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "org.bepinex.plugins.valheim_websocket";
        public const string pluginName = "Valheim WebSocket";
        public const string pluginVersion = "0.1.0";

        void Awake()
        {
            UnityEngine.Debug.Log($"{pluginName} v{pluginVersion}");
        }
    }
}