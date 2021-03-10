using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;
using ValheimWebSocket.Classes;

namespace ValheimWebSocket
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class ValheimWebSocketPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "org.bepinex.plugins.valheim_websocket";
        public const string pluginName = "Valheim WebSocket";
        public const string pluginVersion = "0.1.0";
        
        private ConfigEntry<int> serverPort;
        private ConfigEntry<string> serverBin;
        private ConfigEntry<string> serverArgs;

        void Awake()
        {
            UnityEngine.Debug.Log($"[VWS] {pluginName} v{pluginVersion}");

            serverPort = Config.Bind("Server", "Port", 60157, "WebSocket server port");
            serverBin = Config.Bind("Server", "Bin", "", "WebSocket server bin path");
            serverArgs = Config.Bind("Server", "Args", "", "WebSocket server bin arguments");

            try
            {
                Harmony harmony = new Harmony(pluginGUID);
                harmony.PatchAll();

                ValheimWebSocketServer.Start(serverPort.Value);

                if (serverBin.Value.Length != 0)
                {
                    ClientLauncher.Start(serverBin.Value, serverArgs.Value);
                }
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
            }
        }
    }
}