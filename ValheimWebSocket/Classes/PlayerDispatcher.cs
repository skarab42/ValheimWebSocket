using BepInEx.Logging;
using System;

namespace ValheimWebSocket.Classes
{
    public class PlayerDispatcher
    {
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("PlayerDispatcher");

        public static void Dispatch(string[] args)
        {
            switch (args[0])
            {
                case "center":
                    Message(MessageHud.MessageType.Center, args[1], args[2]);
                    break;

                case "top-left":
                    Message(MessageHud.MessageType.TopLeft, args[1], args[2]);
                    break;
            }
        }

        public static void Message(MessageHud.MessageType type, string user, string text)
        {
            try
            {
                logger.LogInfo($"Message -> user:{user} text:{text}");
                
                if (Player.m_localPlayer != null)
                {
                    Player.m_localPlayer.Message(type, user + ": " + text);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
            }
        }
    }
}
