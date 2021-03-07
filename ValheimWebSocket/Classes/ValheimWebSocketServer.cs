using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ValheimWebSocket.Classes
{
    public class Hudin
    {
        static int messageID = 0;

        public static void Message(string text)
        {
            try
            {
                var name = "hudini" + messageID++;

                Tutorial.TutorialText t = new Tutorial.TutorialText()
                {
                    m_label = "Hudini Chat 1",
                    m_topic = "Hudini Chat 2",
                    m_name = name,
                    m_text = text
                };

                if (Tutorial.instance && !Tutorial.instance.m_texts.Contains(t))
                {
                    Tutorial.instance.m_texts.Add(t);
                }

                if (Player.m_localPlayer != null)
                {
                    Player.m_localPlayer.ShowTutorial(name);
                }
            }
            catch (Exception)
            {
                // myLogSource.LogError(ex);
            }
        }
    }

    public class API : WebSocketBehavior
    {

        protected override void OnMessage(MessageEventArgs e)
        {
            var message = e.Data;
            Hudin.Message(message);
            Send($"ok -> {message}");
        }
    }

    public class ValheimWebSocketServer
    {
        public static void Start(int port)
        {
            UnityEngine.Debug.Log($"[VWS] Server starting on ws://localhost:{port}");

            var wssv = new WebSocketServer(port);

            // wssv.Log.Level = LogLevel.Debug;
            wssv.AddWebSocketService<API>("/hudin/message");
            wssv.Start();
        }
    }
}
