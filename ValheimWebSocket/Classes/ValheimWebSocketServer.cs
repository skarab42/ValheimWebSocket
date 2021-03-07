using WebSocketSharp;
using WebSocketSharp.Server;

namespace ValheimWebSocket.Classes
{
    public class API : WebSocketBehavior
    {

        protected override void OnMessage(MessageEventArgs e)
        {
            Send("ok");
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
