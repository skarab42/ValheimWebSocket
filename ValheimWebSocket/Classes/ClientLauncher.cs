using BepInEx.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace ValheimWebSocket.Classes
{
    class ClientLauncher
    {
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("ClientLauncher");

        public static void Start(string path, string args)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = path;
                    myProcess.StartInfo.Arguments = args;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.RedirectStandardError = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;

                    logger.LogInfo($"[VWS] Starting Client {path}");

                    myProcess.Start();
                }
            }
            catch (Exception e)
            {
                logger.LogError(e);
            }
        }
    }
}
