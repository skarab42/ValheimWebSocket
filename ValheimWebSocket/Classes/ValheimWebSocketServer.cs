using BepInEx.Logging;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ValheimWebSocket.Classes
{
    public class API : WebSocketBehavior
    {

        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("API");

        protected override void OnMessage(MessageEventArgs e)
        {
            var url = e.Data;
            var args = url.Split('/');

            if (args.Length == 0)
            {
                logger.LogError("No arguments provided");
                return;
            }

            logger.LogInfo($"OnMessage {url}");

            switch (args[0])
            {
                case "message":
                    logger.LogInfo($"Dispatch {url}");
                    MessageDispatcher.Dispatch(args.SubArray(1, args.Length - 1));
                    break;
            }
        }
    }

    public class ValheimWebSocketServer
    {
        public static void Start(int port)
        {
            UnityEngine.Debug.Log($"[VWS] Server starting on ws://localhost:{port}");

            var wssv = new WebSocketServer(port);

            // wssv.Log.Level = LogLevel.Debug;
            wssv.AddWebSocketService<API>("/");
            wssv.Start();
        }
    }
}
