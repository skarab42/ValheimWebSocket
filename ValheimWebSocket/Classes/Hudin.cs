using System;

namespace ValheimWebSocket.Classes
{
    public class Hudin
    {
        static int messageID = 0;

        public static void Dispatch(string[] args)
        {
            switch (args[0])
            {
                case "message":
                    Message(args[1], args[2]);
                    break;
            }
        }

        // ws:/hudini/message/<user>/<text>
        public static void Message(string user, string text)
        {
            try
            {
                var name = "hudini" + messageID++;

                Tutorial.TutorialText t = new Tutorial.TutorialText()
                {
                    m_label = "Hudin Chat",
                    m_topic = user,
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
}
