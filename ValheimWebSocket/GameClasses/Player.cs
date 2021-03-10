using HarmonyLib;
using System.Collections.Generic;

namespace ValheimWebSocket
{
    [HarmonyPatch(typeof(Player), "Load")]
    public static class ModifyLoad
    {
        public static void Postfix(ref HashSet<string> ___m_shownTutorials)
        {
            // Remove old custom tutorial messages
            int count = ___m_shownTutorials.Count;

            ___m_shownTutorials.RemoveWhere(hash => hash.StartsWith("vwsp_"));

            UnityEngine.Debug.Log($"Removed {count - ___m_shownTutorials.Count} messages");
        }
    }

    [HarmonyPatch(typeof(Player), "OnSpawned")]
    public static class ModifyOnSpawned
    {
        public static void Postfix(ref HashSet<string> ___m_shownTutorials)
        {
            // Show plugin intro
            Tutorial.TutorialText modIntro = new Tutorial.TutorialText()
            {
                m_name = "vwsp_intro",
                m_label = "vwsp_intro",
                m_topic = "Welcome to ValheimWebSocket",
                m_text = "Follow me on twitch.tv/skarab42",
            };

            if (!Tutorial.instance.m_texts.Contains(modIntro))
            {
                UnityEngine.Debug.Log($"Add text {modIntro.m_label}");

                Tutorial.instance.m_texts.Add(modIntro);
            }

            Player.m_localPlayer.ShowTutorial(modIntro.m_name);
        }
    }
    
}
