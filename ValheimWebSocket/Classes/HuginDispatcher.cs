using BepInEx.Logging;
using System;

namespace ValheimWebSocket.Classes
{
    public class HuginDispatcher
    {
        static int keyID = 0;

        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Hugin");

        public static void Dispatch(string[] args)
        {
            switch (args[0])
            {
                case "message":
                    Message(args[1], args[2]);
                    break;
            }
        }

        // ws:/hugin/message/<user>/<text>
        public static void Message(string user, string text)
        {
            try
            {
                logger.LogInfo($"Message -> user:{user} text:{text}");

                Raven.RavenText ravenText = new Raven.RavenText();

                var key = "vwsp_" + keyID++;
                var label = key;
                var topic = user;
                var munin = true;

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
