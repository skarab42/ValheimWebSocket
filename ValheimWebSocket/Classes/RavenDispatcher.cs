using BepInEx.Logging;
using System;

namespace ValheimWebSocket.Classes
{
    public class RavenDispatcher
    {
        static int keyID = 0;

        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Hugin");

        public static void Dispatch(string[] args)
        {
            switch (args[0])
            {
                case "hugin":
                    Message(args[1], args[2], false);
                    break;
                case "munin":
                    Message(args[1], args[2], true);
                    break;
            }
        }

        public static void Message(string user, string text, bool munin)
        {
            try
            {
                logger.LogInfo($"Message -> user:{user} text:{text}");

                Raven.RavenText ravenText = new Raven.RavenText();

                var key = "vwsp_" + keyID++;
                var label = user;
                var topic = user;

                logger.LogInfo($"AddTempText -> {key}");

                Raven.AddTempText(key, topic, text, label, munin);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
            }
        }
    }
}
