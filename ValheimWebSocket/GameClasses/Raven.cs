using HarmonyLib;

namespace ValheimWebSocket
{
    [HarmonyPatch(typeof(Raven), "Awake")]
    public static class ModifyOnAwake
    {
        private static void Postfix()
        {
            
        }
    }
    
}
