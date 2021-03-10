using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;
using ValheimWebSocket.Classes;
using System.IO;

namespace ValheimWebSocket
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class ValheimWebSocketPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "org.bepinex.plugins.valheim_websocket";
        public const string pluginName = "Valheim WebSocket";
        public const string pluginVersion = "0.1.0";
        
        private ConfigEntry<int> serverPort;
        private ConfigEntry<string> clientBin;
        private ConfigEntry<string> clientArgs;

        void Awake()
        {
            UnityEngine.Debug.Log($"[VWS] {pluginName} v{pluginVersion}");

            var bin = Path.Combine(Paths.PluginPath, "ValheimWebSocket/client.exe");

            serverPort = Config.Bind("Server", "Port", 60157, "WebSocket server port");
            clientBin = Config.Bind("Client", "BinPath", bin, "WebSocket server bin path");
            clientArgs = Config.Bind("Client", "BinArgs", "", "WebSocket server bin arguments");

            try
            {
                Harmony harmony = new Harmony(pluginGUID);
                harmony.PatchAll();

                ValheimWebSocketServer.Start(serverPort.Value);

                if (clientBin.Value.Length != 0)
                {
                    ClientLauncher.Start(clientBin.Value, clientArgs.Value);
                }
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
            }
        }
    }
}