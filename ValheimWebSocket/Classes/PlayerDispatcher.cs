using BepInEx.Logging;
using System;

namespace ValheimWebSocket.Classes
{
    public class PlayerDispatcher
    {
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Player");

        public static void Dispatch(string[] args)
        {
            switch (args[0])
            {
                case "message":
                    Message(args[1], args[2]);
                    break;
            }
        }

        // ws:/player/message/<user>/<text>
        public static void Message(string user, string text)
        {
            try
            {
                logger.LogInfo($"Message -> user:{user} text:{text}");
                
                if (Player.m_localPlayer != null)
                {
                    Player.m_localPlayer.Message(MessageHud.MessageType.Center, user + ": " + text);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
            }
        }
    }
}
